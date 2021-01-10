using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Models;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CbtApi.Core.Managers
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository _questionRepo;

        private readonly IQuestionValidator _questionValidator;

        public QuestionManager(IQuestionRepository questionRepo, IQuestionValidator questionValidator)
        {
            _questionRepo = questionRepo;
            _questionValidator = questionValidator;
        }

        public async Task<QuestionResponseModel> CreateQuestionAsync(QuestionRequestModel model, string userId)
        {
            string message;

            bool success = _questionValidator.ValidateQuestion(model, out message);

            if (!success)
            {
                throw new ProcessException(message);
            }

            var newQuestion = await _questionRepo.CreateQuestionAsync(model, userId);

            return newQuestion;
        }
        public async Task<PagedModel<QuestionResponseModel>> GetUserQuestionsAsync(string userId, string subjectId, string difficultyLevelId, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            var pagedQuestion = await _questionRepo.GetUserQuestionsAsync(userId, subjectId, difficultyLevelId, pageNumber, pageSize);

            return pagedQuestion;
        }
        public async Task<bool> IsOwnerOfQuestionAsync(string questionId, string userId)
        {
            return await _questionRepo.IsOwnerOfQuestionAsync(questionId, userId);
        }
        public async Task<QuestionResponseModel> UpdateQuestionAsync(string questionId, QuestionRequestModel model, string userId)
        {
            string message;

            bool success = _questionValidator.ValidateQuestion(model, out message);

            if (!success)
            {
                throw new ProcessException(message);
            }

            return await _questionRepo.UpdateQuestionAsync(questionId, model, userId);

        }
     
        public async Task<bool> DeleteQuestionAsync(string id)
        {
            bool success = false;
            //get question
            var model = await _questionRepo.GetQuestionAsync(id);

            if (model == null) throw new ProcessException("Question is not found");

            await _questionRepo.DeleteQuestionAsync(id);

            return true;
        }
        public async Task<QuestionResponseModel> GetUserQuestionAsync(string userId, string questionId)
        {
            var question = await _questionRepo.GetQuestionAsync(questionId);

            if (question == null) throw new ProcessException("Question not found");
             

            return question;
        }

     
    }
}
