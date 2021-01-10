using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbtApi.Infrastructure.Validator
{
    public class QuestionValidator : IQuestionValidator
    {
        public bool ValidateNumberOfOptions(QuestionRequestModel model, out string message)
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
        public bool ValidateQuestion(QuestionRequestModel model, out string message)
        {
            bool success = false;

            success = ValidateQuestionType(model, out message);

            if (!success)
            {
                return false;
            }

            success = ValidateNumberOfOptions(model, out message);

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
    }
}
