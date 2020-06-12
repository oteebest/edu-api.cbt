using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CbtApi.Core.Models.RequestModels
{
    public class QuestionRequestModel
    {
        [Required(ErrorMessage = "Provide question type")]
        public string QuestionType { get; set; }

        [Required(ErrorMessage = "Enter score value")]
        public int ? ScoreValue { get; set; }

        [Required(ErrorMessage = "Enter question")]
        public string Text { get; set; }


        [Required(ErrorMessage = "Select number of options")]
        public int ? OptionCount { get; set; }

        [Required(ErrorMessage = "Indicate schuffle option")]
        public bool ? ShuffleOptions { get; set; }

        [Required(ErrorMessage = "Options are required")]
        public List<QuestionOption> Options { get; set; } = new List<QuestionOption>();

        [Required(ErrorMessage = "Select difficulty level")]
        public string DifficultyLevelId { get; set; }

        [Required(ErrorMessage = "Select subject")]
        public string SubjectId { get; set; }
    }

    public class QuestionOption
    {
        [Required(ErrorMessage = "Answer for each option must be true or false")]
        public bool ? IsAnswer { get; set; }

        [Required(ErrorMessage = "Every option must have information")]
        public string Text { get; set; }
    }


}
