using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public async Task DeleteAssesmentAsync(string id)
        {
            await _assessmentRepo.DeleteAssessmentAsync(id);
        }

        public async Task<AssessmentResponseModel> GetAssessmentsAsync(string id)
        {
            var assesment = await _assessmentRepo.GetAssesmentAsync(id);

            if (assesment == null) throw new ProcessException("Assessment not found");

            return assesment;
        }

        public async Task<IEnumerable<AssessmentResponseModel>> GetUserAssessmentsAsync(string userId)
        {
            return await _assessmentRepo.GetUserAsessmentsAsync(userId);
        }

        public async Task<bool> IsOwnerOfAssesmentAsync(string assesmentId, string userId)
        {
           
            return await _assessmentRepo.AssesmentBelongsToUserAsync(assesmentId, userId);


        }

        public async Task<AssessmentResponseModel> UpdateAssessmentAsync(string id, AssessmentRequestModel model)
        {           
            return await _assessmentRepo.UpdateAssessmentAsync(id,model);
        }
    }
}
