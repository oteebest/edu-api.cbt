using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Infrastructure.Repository
{
    public class SubscriptionRespository : ISubscriptionRepository
    {
        private readonly AppDbContext _db;

        public SubscriptionRespository(AppDbContext db)
        {
            _db = db;
        }
      
    }
}
