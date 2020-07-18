using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Core.Managers
{
    public class PredefindDataManager : IPredefindDataManager
    {
        IPredefinedDataRespository _predefinedRepo;

        public PredefindDataManager(IPredefinedDataRespository predefinedRepo)
        {
            _predefinedRepo = predefinedRepo;
        }

        public async Task<PredefinedResponseModel> GetPredefinedDataAsync()
        {
           return await  _predefinedRepo.GetPredefindDataAsync();
        }
    }
}
