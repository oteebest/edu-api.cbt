using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Managers;
using CbtApi.Core.Models.RequestModels;
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
       
        private readonly QuestionManager _questionManager;
        private readonly Mock<IQuestionRepository> _questionRepoMock;

        public QuestionValidationTest()
        {
            _questionRepoMock = new Mock<IQuestionRepository>();

            _questionManager = new QuestionManager(_questionRepoMock.Object);

           
        }




        [ClassData(typeof(QuestionTestData))]
        [Theory]
        public void ValidateNumberOfOptions(QuestionRequestModel requestModel)
        {
            bool success = _questionManager.ValidateNumberOfOptions(requestModel, out string message);

            Assert.True(success, message);

        }

        [Theory]
        [ClassData(typeof(QuestionTestData))]       
        public void ValidateQuestionOptions(QuestionRequestModel requestModel)
        {
            bool success = _questionManager.ValidateQuestionOptions(requestModel, out string message);

            Assert.True(success, message);

        }

        [Theory]
        [ClassData(typeof(QuestionTestData))]       
        public void ValidateQuestionType(QuestionRequestModel requestModel)
        {
            bool success = _questionManager.ValidateQuestionType(requestModel, out string message);

            Assert.True(success, message);

        }

        [ClassData(typeof(QuestionTestData))]
        [Theory]
        public void ValidateQuestion(QuestionRequestModel requestModel)
        {
            bool success = _questionManager.ValidateQuestion(requestModel, out string message);

            Assert.True(success, message);

        }
    }
}
