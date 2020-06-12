using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Interface.IRepository
{
    public interface IAssessmentRepository
    {
        Task<AssessmentResponseModel> CreateAssessmentAsync(AssessmentRequestModel model,string userId);
        Task<AssessmentResponseModel> UpdateAssessmentAsync(string id, AssessmentRequestModel model);
        Task<AssessmentResponseModel> GetAssesmentAsync(string assesmentId);

        Task<bool> AssesmentBelongsToUserAsync(string assesmentId, string userId);

        Task<IEnumerable<AssessmentResponseModel>> GetUserAsessmentsAsync(string userId);
        Task DeleteAssessmentAsync(string id);
    }
}
