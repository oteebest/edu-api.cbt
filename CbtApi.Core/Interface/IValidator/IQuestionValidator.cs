using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Interface.IValidator
{
    public interface IQuestionValidator
    {
        bool ValidateNumberOfOptions(QuestionRequestModel model, out string message);

        bool ValidateQuestionType(QuestionRequestModel model, out string message);

        bool ValidateQuestionOptions(QuestionRequestModel model, out string message);

        bool ValidateQuestion(QuestionRequestModel model, out string message);
    }
}
