using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Managers
{
    public class AssessmentManager : IAssessmentManager
    {
        private readonly IAssessmentRepository _assessmentRepo;
     

        public AssessmentManager(IAssessmentRepository assessmentRepo)
        {
            _assessmentRepo = assessmentRepo;
        }

        public  async Task<AssessmentResponseModel> CreateAssessment(AssessmentRequestModel model,string userId)
        {
             return await _assessmentRepo.CreateAssessmentAsync(model, userId);
        }

        public async Task<IEnumerable<AssessmentResponseModel>> GetUserAssessmentsAsync(string userId)
        {
            return await _assessmentRepo.GetUserAsessmentsAsync(userId);
        }

        public async Task<bool> IsOwnerOfAssesmentAsync(string assesmentId, string userId)
        {
           
            return await _assessmentRepo.AssesmentBelongsToUserAsync(assesmentId, userId);


        }
    }
}
