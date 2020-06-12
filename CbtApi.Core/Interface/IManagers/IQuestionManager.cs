using CbtApi.Core.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Interface.IManagers
{
    public interface IQuestionManager
    {
        Task<QuestionResponseModel> CreateQuestionAsync(QuestionRequestModel model, string userId);
        Task<bool> IsOwnerOfQuestionAsync(string questionId, string userId);
        Task<QuestionResponseModel> UpdateQuestionAsync(string questionId,QuestionRequestModel model, string userId);

        Task<PagedModel<QuestionResponseModel>> GetUserQuestionsAsync(string userId, string subjectId, string difficultyLevelId, int pageNumber, int pageSize);
    }
}
