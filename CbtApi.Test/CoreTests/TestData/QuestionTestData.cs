using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CbtApi.Test.CoreTests.TestData
{
    public  class QuestionTestData : TheoryData<QuestionRequestModel>
    {
        public QuestionTestData()
        {
            Add(new QuestionRequestModel
            {
                DifficultyLevelId = "ce705f44-07e0-45c6-b51d-3b1af6256848",
                ShuffleOptions = true,
                ScoreValue = 10,
                SubjectId = "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c0",
                QuestionType = "MultipleChoice",
                Text = "Test Question",
                Options = new List<QuestionOption> { new QuestionOption{ IsAnswer = true, Text = "Option text"},
                new QuestionOption{ IsAnswer = true, Text = "Option text"}
                }
            });

            Add(new QuestionRequestModel
            {
                DifficultyLevelId = "ce705f44-07e0-45c6-b51d-3b1af6256848",
                ShuffleOptions = true,
                ScoreValue = 10,
                SubjectId = "f4eb2f0a-ef7f-4d16-abc2-dfabf6b660c0",
                QuestionType = "SingleChoice",
                Text = "Test Question",
                Options = new List<QuestionOption> { new QuestionOption{ IsAnswer = true, Text = "Option text"},
                new QuestionOption{ IsAnswer = false, Text = "Option text"}
                }
            });
        }

      
    }
}
