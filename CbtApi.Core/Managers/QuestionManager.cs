using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Managers
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionManager(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public async Task<QuestionResponseModel> CreateQuestionAsync(QuestionRequestModel model, string userId)
        {
            ValidateQuestion(model);

           return await _questionRepo.CreateQuestionAsync(model, userId);

        }

        public async Task<PagedModel<QuestionResponseModel>> GetUserQuestionsAsync(string userId,string subjectId,string difficultyLevelId,int pageNumber,int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            return await _questionRepo.GetUserQuestionsAsync(userId, subjectId, difficultyLevelId,pageNumber,pageSize);

        }
        public async Task<bool> IsOwnerOfQuestionAsync(string questionId, string userId)
        {
            return await _questionRepo.IsOwnerOfQuestionAsync(questionId, userId);
        }

        public async Task<QuestionResponseModel> UpdateQuestionAsync(string questionId,QuestionRequestModel model, string userId)
        {
            ValidateQuestion(model);

            return await _questionRepo.UpdateQuestionAsync( questionId, model, userId);

        }

        private void ValidateQuestion(QuestionRequestModel model)
        {
            if (!Enum.GetNames(typeof(QuestionType)).Contains(model.QuestionType))
            {
                throw new ProcessException("Invalid question type");
            }

            if(model.OptionCount <= 0)
            {
                throw new ProcessException("Options must be greater than one");
            }
            else if(model.OptionCount != model.Options.Count)
            {
                throw new ProcessException($"Number of options must be {model.OptionCount}");
            }

            if (model.QuestionType.Equals(QuestionType.SingleChoice.ToString()))
            {
                int countAnswers = model.Options.Where(u => u.IsAnswer.Value).Count();

                if (countAnswers == 0)
                {
                    throw new ProcessException($"You must have a least one answer for single choice questions");
                }

                if (countAnswers > 1)
                {
                    throw new ProcessException($"Number of answers must be only one for a single choice question");
                }

            }

            if (model.QuestionType.Equals(QuestionType.MultipleChoice.ToString()))
            {
                int countAnswers = model.Options.Where(u => u.IsAnswer.Value).Count();

                if (countAnswers < 1)
                {
                    throw new ProcessException($"Number of answers must be one or more for a multiple choice question");
                }

            }
        }
    }
}
