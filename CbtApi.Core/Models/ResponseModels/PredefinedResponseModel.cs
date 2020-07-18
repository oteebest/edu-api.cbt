using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Models.ResponseModels
{
    public class PredefinedResponseModel
    {
        public IEnumerable<SubjectResponseModel> subjects { get; set; } = new List<SubjectResponseModel>();
        public IEnumerable<DifficultLevelResponseModel> difficultyLevels { get; set; } = new List<DifficultLevelResponseModel>();
    }

    public class SubjectResponseModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class DifficultLevelResponseModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }


}
