using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Managers;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
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
        private readonly QuestionModel question;
        private readonly QuestionManager _questionManager;
        private readonly Mock<IQuestionRepository> _questionRepoMock;

        public QuestionManagerTest()
        {


            question = new QuestionModel
            {
                DifficultyLevelId = "ce705f44-07e0-45c6-b51d-3b1af6256848",
                ShuffleOptions = true,
                ScoreValue = 10,
                SubjectId = "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c0",
                QuestionType = "",
                Text = "Test Question",
                UserId = "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c3",
                 Id = "ce705f44-07e0-45c6-b51d-3b1af6256848",                 
                Options = new List<QuestionOption> { new QuestionOption{ IsAnswer = true, Text = "Option text"},
                new QuestionOption{ IsAnswer = true, Text = "Option text"}
                },
                
            };

            _questionRepoMock = new Mock<IQuestionRepository>();

            _questionRepoMock.Setup(u =>  u.GetQuestionAsync(question.Id))
                .Returns(Task.FromResult(question));

            _questionManager = new QuestionManager(_questionRepoMock.Object);

        }


     
        [InlineData("ce705f44-07e0-45c6-b51d-3b1af6256848", "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c3")]
        [Theory]
        public async Task DeleteQuestion(string questionId,string userId)
        {
            var success = await _questionManager.DeleteQuestionAsync(questionId,userId);

            Assert.True(success);

        }




    }
}
