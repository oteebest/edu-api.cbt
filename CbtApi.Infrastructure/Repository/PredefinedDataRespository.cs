using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using CbtApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Infrastructure.Repository
{
    public class PredefinedDataRespository : IPredefinedDataRespository
    {
        private readonly AppDbContext _db;
        public PredefinedDataRespository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<PredefinedResponseModel> GetPredefindDataAsync()
        {
            PredefinedResponseModel model = new PredefinedResponseModel
            {
                subjects =  await _db.Subjects.Select( u => u.Map()).ToListAsync(),

                difficultyLevels = await _db.DifficultyLevels.Select(u => u.Map()).ToListAsync()

            };

            return model;
        }
    }
}
