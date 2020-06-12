using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Models.ResponseModels
{
    public class AssessmentResponseModel : AssessmentRequestModel
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

       
    }
}
