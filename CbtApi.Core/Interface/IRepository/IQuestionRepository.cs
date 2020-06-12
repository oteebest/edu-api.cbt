using CbtApi.Core.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Interface.IRepository
{
    public interface IQuestionRepository
    {

        Task<QuestionResponseModel> CreateQuestionAsync(QuestionRequestModel model, string userId);


        Task DeleteQuestionAsync(string id);

        Task<List<QuestionResponseModel>> GetAssessmentQuestionsAsync(string id);

        Task<QuestionResponseModel> GetQuestionsAsync(string id);

        Task<bool> IsOwnerOfQuestionAsync(string id, string userId);
        Task<QuestionResponseModel> UpdateQuestionAsync(string questionId, QuestionRequestModel model, string userId);
        Task<PagedModel<QuestionResponseModel>> GetUserQuestionsAsync(string userId, string subjectId,
                string difficultyLevelId, int pageNumber, int pageSize);

    }
}
