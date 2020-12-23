using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using CbtApi.Infrastructure.Context;
using CbtApi.Infrastructure.Entities;
using CbtApi.Infrastructure.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Infrastructure.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _dbContext;

        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QuestionModel> CreateQuestionAsync(QuestionRequestModel model, string userId)
        {
          
            var question = model.Map(userId);

            _dbContext.Add(question);

            await _dbContext.SaveChangesAsync();

            return  await GetQuestionAsync(question.Id);

        }

        public async Task<int> DeleteQuestionAsync(string id)
        {           
            var count = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Delete question Where id = {id}");
            return count;
        }

     

        public async Task<QuestionModel> GetQuestionAsync(string id)
        {
            var question = await _dbContext.Questions
                                           .Include(u => u.DifficultyLevel)
                                           .Include(u => u.Subject)
                                           .FirstOrDefaultAsync(u => u.Id.Equals(id)); ;

            return question.Map();
        }

        public async Task<PagedModel<QuestionModel>> GetUserQuestionsAsync(string userId, string subjectId,
            string difficultyLevelId, int pageNumber, int pageSize)
        {

            var queryable = _dbContext.Questions
                .Include(u => u.Options)
                .Include(u => u.DifficultyLevel)
                .Include(u => u.Subject)
                .Where(u => u.UserId == userId);

            if (!string.IsNullOrEmpty(subjectId))
            {
                queryable = queryable.Where(u => u.SubjectId.Equals(subjectId));
            }

            if (!string.IsNullOrEmpty(difficultyLevelId))
            {
                queryable = queryable.Where(u => u.DifficultyLevelId.Equals(difficultyLevelId));
            }

            var data = await queryable.ToPagedList(pageNumber, pageSize);


            return new PagedModel<QuestionModel>(data.Items.Select(u => u.Map()).ToArray(),
               data.TotalSize,  data.PageNumber, data.PageSize);

        }

        public async Task<bool> IsOwnerOfQuestionAsync(string id,string userId)
        {
            var question = await _dbContext.Questions.FirstOrDefaultAsync(u => u.Id.Equals(id) && u.UserId.Equals(userId));

            if (question == null) throw new ProcessException("Question not found");

            return question.UserId.Equals(userId);
        }

   

        public async Task<QuestionModel> UpdateQuestionAsync(string questionId, QuestionRequestModel model, string userId)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    var entity = _dbContext.Questions.First(u => u.Id == questionId);

                    entity.Text = model.Text;
                    entity.SubjectId = model.SubjectId;
                    entity.ScoreValue = model.ScoreValue.Value;
                    entity.QuestionType = model.QuestionType;
                    entity.ShuffleOptions = model.ShuffleOptions.Value;
                    entity.DifficultyLevelId = model.DifficultyLevelId;
                    entity.Options = model.Options.Select(u => new Option { Text = u.Text, IsAnswer = u.IsAnswer.Value }).ToList();

                    var question = model.Map(userId, questionId);

                    var options = _dbContext.Options.Where(u => u.QuestionId == questionId);

                    _dbContext.RemoveRange(options);

                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
              
            }
            

            return await GetQuestionAsync(questionId);
        }
    }
}
