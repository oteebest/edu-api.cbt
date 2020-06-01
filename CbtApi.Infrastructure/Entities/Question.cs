using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Question : Entity
    {
        public string QuestionType { get; set; }
        public bool ShuffleOptions { get; set; }
        public int OptionCount { get; set; }
        public string QuestionGroupId { get; set; }
        public QuestionGroup QuestionGroup { get; set; }
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
        public int DifficultyLevelId { get; set; }
        public int SubjectId { get; set; }
        public int ScoreValue { get; set; }
        public List<Option> Options { get; set; }     
        public string UserId { get; set; }

    }
}
