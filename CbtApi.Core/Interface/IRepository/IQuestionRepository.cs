using CbtApi.Core.Models;
using CbtApi.Core.Models.Models;
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

        Task<QuestionModel> CreateQuestionAsync(QuestionRequestModel model, string userId);


         Task<int> DeleteQuestionAsync(string questionId);
     
        Task<QuestionModel> GetQuestionAsync(string id);

        Task<bool> IsOwnerOfQuestionAsync(string id, string userId);
        Task<QuestionModel> UpdateQuestionAsync(string questionId, QuestionRequestModel model, string userId);
        Task<PagedModel<QuestionModel>> GetUserQuestionsAsync(string userId, string subjectId,
                string difficultyLevelId, int pageNumber, int pageSize);
        
    }
}
