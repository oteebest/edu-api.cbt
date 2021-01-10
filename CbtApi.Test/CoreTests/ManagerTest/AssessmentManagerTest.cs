using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Managers;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CbtApi.Test
{
    public class AssessmentManagerTest
    {
        private readonly AssessmentManager _assessmentManager;
        private readonly Mock<IAssessmentRepository> _assessmentRepo;
        private readonly Mock<IAssessmentValidator> _assessmentValidator;
        private readonly AssessmentRequestModel _assessmentRequestModel;
        private readonly AssessmentResponseModel _assessmentResponseModel;

        private readonly string userId = "ce705f44-07e0-45c6-b51d-3b1af6256848";
        public AssessmentManagerTest()
        {
            _assessmentRepo = new Mock<IAssessmentRepository>(MockBehavior.Strict);

            _assessmentValidator = new Mock<IAssessmentValidator>(MockBehavior.Strict);

            _assessmentManager = new AssessmentManager(_assessmentRepo.Object, _assessmentValidator.Object);

            _assessmentRequestModel = new AssessmentRequestModel { Duration = 1, Instructions = "instruction", Name = "Otee" };

            _assessmentResponseModel = new AssessmentResponseModel
            {
                CreatedOn = DateTime.Now,
                Id = "ce705f44-07e0-45c6-b51d-3b1af6256848",
                Duration = _assessmentRequestModel.Duration,
                Instructions = _assessmentRequestModel.Instructions,
                Name = _assessmentRequestModel.Name
            };

        }



        [Fact]
        public async Task ShouldCreateAssessment()
        {
           
          
            _assessmentValidator.Setup(u => u.AssessmentDurationIsGreaterThanZero(_assessmentRequestModel))
                .Returns(true);

            _assessmentRepo.Setup(u => u.CreateAssessmentAsync(_assessmentRequestModel, userId))
                .Returns(() => Task.FromResult(_assessmentResponseModel));

                
            var response = await _assessmentManager.CreateAssessment(_assessmentRequestModel, userId);

            Assert.NotNull(response.Id);

        }


        [Fact]
        public async Task ShouldThrowProcessExceptionWhenDurationIsLessThanOne()
        {
           
            _assessmentValidator.Setup(u => u.AssessmentDurationIsGreaterThanZero(_assessmentRequestModel))
                .Returns(false);

            _assessmentRepo.Setup(u => u.CreateAssessmentAsync(_assessmentRequestModel, userId))
               .Returns(() => Task.FromResult(_assessmentResponseModel));

            await Task.Yield();

            await Assert.ThrowsAsync<ProcessException>(() =>   _assessmentManager.CreateAssessment(_assessmentRequestModel, "ce705f44-07e0-45c6-b51d-3b1af6256848"));

            _assessmentRepo.Verify(u => u.CreateAssessmentAsync(_assessmentRequestModel, userId), Times.Never);

        }

    }
}
