using System.ComponentModel.DataAnnotations;

namespace CbtApi.Core.Models.RequestModels
{
    public class AsssesmentProcessingBaseModel
    {
        [Required(ErrorMessage = "Enter assessment name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter assessment instructions")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Enter duration in minutes")]
        public int? Duration { get; set; }
    }
}