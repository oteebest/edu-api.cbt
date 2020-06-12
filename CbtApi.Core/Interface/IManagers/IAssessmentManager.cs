using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Interface.IManagers
{
    public interface IAssessmentManager
    {
        Task<AssessmentResponseModel> CreateAssessment(AssessmentRequestModel model, string userId);

        Task<AssessmentResponseModel> UpdateAssessmentAsync(string id, AssessmentRequestModel model);

        Task<bool> IsOwnerOfAssesmentAsync(string assesmentId, string userId);

        Task<IEnumerable<AssessmentResponseModel>> GetUserAssessmentsAsync(string userId);

        Task<AssessmentResponseModel> GetAssessmentsAsync(string id);

        Task DeleteAssesmentAsync(string id);
    }
}
