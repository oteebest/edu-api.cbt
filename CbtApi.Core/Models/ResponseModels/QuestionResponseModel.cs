using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Models.ResponseModels
{
    public class QuestionResponseModel : QuestionModelBase
    {
        public string Id { get; set; }
        public string DifficultyLevel { get; set; }
        public string Subject { get; set; }
    }
}
