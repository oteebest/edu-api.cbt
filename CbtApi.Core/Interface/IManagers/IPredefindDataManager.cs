using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Interface.IManagers
{
    public interface IPredefindDataManager
    {
        Task<PredefinedResponseModel> GetPredefinedDataAsync();
    }
}
