using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Interface.IValidator
{
    public interface IAssessmentValidator
    {
        bool AssessmentDurationIsGreaterThanZero(AssessmentRequestModel model);

    }
}
