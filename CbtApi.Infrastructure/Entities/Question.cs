using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Question : Entity
    {
        public string QuestionType { get; set; }     
        public int ScoreValue { get; set; }
        public int OptionCount { get; set; }
        public bool ShuffleOptions { get; set; }
        public List<Option> Options { get; set; }     
        public string UserId { get; set; }

        public string  DifficultyLevelId { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }
        public string SubjectId { get; set; }

        public Subject Subject { get; set; }
        public string Text { get;  set; }
    }
}
