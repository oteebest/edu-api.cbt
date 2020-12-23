using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string message;

            bool success = ValidateQuestion(model, out message);

            if (!success)
            {
                throw new ProcessException(message);
            }

            return await _questionRepo.CreateQuestionAsync(model, userId);

        }

        public async Task<PagedModel<QuestionResponseModel>> GetUserQuestionsAsync(string userId,string subjectId,string difficultyLevelId,int pageNumber,int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            var pagedQuestion = await _questionRepo.GetUserQuestionsAsync(userId, subjectId, difficultyLevelId,pageNumber,pageSize);

            return pagedQuestion.Map();
        }
        public async Task<bool> IsOwnerOfQuestionAsync(string questionId, string userId)
        {
            return await _questionRepo.IsOwnerOfQuestionAsync(questionId, userId);
        }

        public async Task<QuestionResponseModel> UpdateQuestionAsync(string questionId,QuestionRequestModel model, string userId)
        {
            string message; 

            bool success = ValidateQuestion(model,out message);

            if (!success)
            {
                throw new ProcessException(message);
            }

            return await _questionRepo.UpdateQuestionAsync( questionId, model, userId);

        }

    
      
        public bool ValidateNumberOfOptions(QuestionRequestModel model,out string message)
        {
            if (model.Options.Count > 1)
            {
                message = "Options are more than one";
                return true;
            }
            else
            {
                message = $"Question options must be greater than one. You currently have only { model.Options.Count}";
                return false;
            }
        }

        public bool ValidateQuestionType(QuestionRequestModel model, out string message)
        {
            message = string.Empty;

            if (!Enum.GetNames(typeof(QuestionType)).Contains(model.QuestionType))
            {
                message = "Invalid question type";
                return false;

            }

            return true;
        }

        public bool ValidateQuestionOptions(QuestionRequestModel model, out string message)
        {
            if (model.QuestionType.Equals(QuestionType.SingleChoice.ToString()))
            {
                int countAnswers = model.Options.Where(u => u.IsAnswer.Value).Count();

                if (countAnswers == 0)
                {
                    message = $"You must have a least one answer for single choice questions";
                    return false;
                }

                if (countAnswers > 1)
                {
                    message = $"Number of answers must be only one for a single choice question";
                    return false;
                }

                message = $"Validation successful";
                return true;
            }
            else if (model.QuestionType.Equals(QuestionType.MultipleChoice.ToString()))
            {
                int countAnswers = model.Options.Where(u => u.IsAnswer.Value).Count();

                if (countAnswers < 1)
                {
                    message = $"Number of answers must be one or more for a multiple choice question";
                    return false;
                }


                message = $"Validation successful";
                return true;
            }
            else
            {
                message = $"Invalid quesiton type";
                return false;

            }

        }

        public bool ValidateQuestion(QuestionRequestModel model,out string message)
        {
            bool success = false;

            success = ValidateQuestionType(model, out message);

            if (!success)
            {
                return false;
            }

            success = ValidateNumberOfOptions(model,out message);

            if (!success)
            {
                return false;
            }

            success = ValidateQuestionOptions(model, out message);

            if (!success)
            {
                return false;
            }


            return true;
        }

        public async Task<bool> DeleteQuestionAsync(string id, string userId)
        {
            bool success = false;
            //get question
           var model = await _questionRepo.GetQuestionAsync(id);

            if (model == null) throw new ProcessException("Question is not found");

            success = ValidateQuestionBelongsToUser(model, userId, out string message);


            if (!success) throw new ProcessException(message);

            await _questionRepo.DeleteQuestionAsync(id);

            return true;
        }



        public async Task<QuestionResponseModel> GetUserQuestionAsync(string userId, string questionId)
        {
            var question = await _questionRepo.GetQuestionAsync(questionId);

            if (question == null) throw new ProcessException("Question not found");

            bool success = ValidateQuestionBelongsToUser(question, userId, out string message);

            if (!success) throw new ProcessException(message);

            return question;
        }

        private bool ValidateQuestionBelongsToUser(QuestionModel question, string userId,out string message)
        {
            bool success = question.UserId == userId;

            message = success ? "Question belongs to user" : "Question does not belong to user";

            return success;
        }
    }
}
