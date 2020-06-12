using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CbtApi.Core.Models.RequestModels
{
    public class AssessmentRequestModel 
    {
        [Required(ErrorMessage ="Enter assessment name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter assessment instructions")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Enter duration in minutes")]
        public int ? Duration { get; set; }
    }
}
