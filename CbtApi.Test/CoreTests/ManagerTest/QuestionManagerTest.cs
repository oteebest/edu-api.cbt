using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Managers;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using CbtApi.Infrastructure.Validator;
using CbtApi.Test.CoreTests.TestData;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CbtApi.Test
{
    public class QuestionManagerTest
    {
        private readonly QuestionResponseModel questionResponse;
        private readonly QuestionRequestModel questionRequest;
        private readonly QuestionManager _questionManager;
        private readonly Mock<IQuestionRepository> _questionRepoMock;
        private readonly Mock<IQuestionValidator> _questionValidator;
        private string validatorMessage;
        public QuestionManagerTest()
        {


            questionResponse = new QuestionResponseModel
            {
                DifficultyLevelId = "ce705f44-07e0-45c6-b51d-3b1af6256848",
                ShuffleOptions = true,
                ScoreValue = 10,
                SubjectId = "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c0",
                QuestionType = "",
                Text = "Test Question",            
                 Id = "ce705f44-07e0-45c6-b51d-3b1af6256848",                 
                Options = new List<QuestionOption> { new QuestionOption{ IsAnswer = true, Text = "Option text"},
                new QuestionOption{ IsAnswer = true, Text = "Option text"}
                }, DifficultyLevel = "Easy", Subject = "Mathematics",
                
            };


            _questionRepoMock = new Mock<IQuestionRepository>(MockBehavior.Strict);

            _questionValidator = new Mock<IQuestionValidator>(MockBehavior.Strict);

            validatorMessage = "Is Valid";

            _questionValidator.Setup(u => u.ValidateNumberOfOptions(It.IsAny<QuestionRequestModel>(), out validatorMessage))
                .Returns(true);

            _questionValidator.Setup(u => u.ValidateQuestion(It.IsAny<QuestionRequestModel>(), out validatorMessage))
            .Returns(true);

            _questionValidator.Setup(u => u.ValidateQuestionOptions(It.IsAny<QuestionRequestModel>(), out validatorMessage))
            .Returns(true);

            _questionValidator.Setup(u => u.ValidateQuestionType(It.IsAny<QuestionRequestModel>(), out validatorMessage))
            .Returns(true);

            _questionRepoMock.Setup(u => u.GetQuestionAsync(questionResponse.Id))
                .Returns(Task.FromResult(questionResponse));

           
            _questionManager = new QuestionManager(_questionRepoMock.Object, _questionValidator.Object);

        }

     


     
        [InlineData("ce705f44-07e0-45c6-b51d-3b1af6256848")]
        [Theory]
        public async Task DeleteQuestion(string questionId)
        {
            _questionRepoMock.Setup(u => u.DeleteQuestionAsync(questionId))
                .Returns(() => Task.FromResult(1));

            var success = await _questionManager.DeleteQuestionAsync(questionId);

            Assert.True(success);

        }

        [ClassData(typeof(QuestionTestData))]
        [Theory]
        public async Task CreateQuestion(QuestionRequestModel question)
        {
            _questionRepoMock.Setup(u => u.CreateQuestionAsync(It.IsAny<QuestionRequestModel>(), It.IsAny<string>()))
           .Returns(() => Task.FromResult(questionResponse));

            var response = await _questionManager.CreateQuestionAsync(question, "333");

            _questionRepoMock.Verify(u => u.CreateQuestionAsync(It.IsAny<QuestionRequestModel>(), It.IsAny<string>()), Times.Once);

            Assert.NotNull(response.Id);


        }

        [InlineData("ce705f44-07e0-45c6-b51d-3b1af6256848", "")]
        [Theory]
        public async Task UserIsOwnerOfQuestionAsync(string questionId, string userId)
        {
            _questionRepoMock.Setup(u => u.IsOwnerOfQuestionAsync(questionId, userId))
                .Returns(() => Task.FromResult(true));
          
           bool success =   await _questionManager.IsOwnerOfQuestionAsync(questionId, userId);

            Assert.True(success);
        }

        [InlineData("ce705f44-07e0-45c6-b51d-3b1af6256848", "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c0")]
        [Theory]
        public async Task UpdateQuestionAsync(string questionId,string userId)
        {
            var newRequest = new QuestionRequestModel
            {
                DifficultyLevelId = "ce705f44-07e0-45c6-b51d-3b1af6256848",
                ShuffleOptions = true,
                ScoreValue = 10,
                SubjectId = "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c0",
                QuestionType = "SingleChoice",
                Text = "Test Question",
                Options = new List<QuestionOption> { new QuestionOption{ IsAnswer = true, Text = "Option text"},
                new QuestionOption{ IsAnswer = false, Text = "Option text"}
                },

            };

            _questionRepoMock.Setup(u => u.UpdateQuestionAsync(questionId, newRequest, userId))
                .Returns(() => Task.FromResult(questionResponse));

  
            var response =  await _questionManager.UpdateQuestionAsync(questionId, newRequest, userId);


            _questionValidator.Verify(u => u.ValidateQuestion(It.IsAny<QuestionRequestModel>(), out validatorMessage), Times.Once);

            Assert.NotNull(response.Id);

            

        }

    

    }
}
