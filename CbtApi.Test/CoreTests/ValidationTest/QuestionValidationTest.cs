using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Managers;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Infrastructure.Validator;
using CbtApi.Test.CoreTests.TestData;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CbtApi.Test.CoreTests.ValidationTest
{
    public class QuestionValidationTest
    {
       
        private readonly QuestionValidator _questionValidator;

        public QuestionValidationTest()
        {
            
            _questionValidator = new QuestionValidator();

           
        }




        [ClassData(typeof(QuestionTestData))]
        [Theory]
        public void ValidateNumberOfOptions(QuestionRequestModel requestModel)
        {
            bool success = _questionValidator.ValidateNumberOfOptions(requestModel, out string message);

            Assert.True(success, message);

        }

        [Theory]
        [ClassData(typeof(QuestionTestData))]       
        public void ValidateQuestionOptions(QuestionRequestModel requestModel)
        {
            bool success = _questionValidator.ValidateQuestionOptions(requestModel, out string message);

            Assert.True(success, message);

        }

        [Theory]
        [ClassData(typeof(QuestionTestData))]       
        public void ValidateQuestionType(QuestionRequestModel requestModel)
        {
            bool success = _questionValidator.ValidateQuestionType(requestModel, out string message);

            Assert.True(success, message);

        }

        [ClassData(typeof(QuestionTestData))]
        [Theory]
        public void ValidateQuestion(QuestionRequestModel requestModel)
        {
            bool success = _questionValidator.ValidateQuestion(requestModel, out string message);

            Assert.True(success, message);

        }
    }
}
