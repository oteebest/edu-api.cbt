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
        public int QuestionGroupId { get; set; }
        public int TopicId { get; set; }
        public int DifficultyLevelId { get; set; }
        public int SubjectId { get; set; }
        public int ScoreValue { get; set; }
        public List<Option> Options { get; set; }
        public string SubscriberId { get; set; }

    }
}
