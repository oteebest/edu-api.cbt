using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Infrastructure.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CbtApi.Test.CoreTests.ValidationTest
{
    public class AssessmentValidationTests
    {
        private readonly AssessmentValidator _assValidator;

        private readonly AssessmentRequestModel _assessmentRequest;
        public AssessmentValidationTests()
        {
            _assValidator = new AssessmentValidator();

            _assessmentRequest = new AssessmentRequestModel { Duration = 1, Instructions = "My instructions", Name = "My Assessment Name" };
        }

        [InlineData()]
        [Fact]
        public async Task ValidateAssessment()
        {
            bool durationIsGreaterThanZero = _assValidator.AssessmentDurationIsGreaterThanZero(_assessmentRequest);

            await Task.Yield();

            Assert.True(durationIsGreaterThanZero);
        }

    }
}
