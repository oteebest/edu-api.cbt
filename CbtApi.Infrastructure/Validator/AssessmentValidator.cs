using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Validator
{
    public class AssessmentValidator : IAssessmentValidator
    {
        public bool AssessmentDurationIsGreaterThanZero(AssessmentRequestModel model)
        {
            return model.Duration > 0;
        }
    }
}
