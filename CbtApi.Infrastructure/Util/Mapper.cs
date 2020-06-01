using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Util
{
    public static class Mapper
    {
        public static Assessment Map(this AssessmentRequestModel model,string userId)
        {
            if (model == null) return null;

            return new Assessment { Name = model.Name, UserId = userId };
        }

        public static AssessmentResponseModel Map(this Assessment entity)
        {
            if (entity == null) return null;

            return new AssessmentResponseModel
            {
                Name = entity.Name,
                CreateOn =
                entity.CreateOn,
                Id = entity.Id
            };

        }

        #region UserSubscription
        public static UserSubscriptionResponseModel Map(this UserSubscription entity)
        {
            if (entity == null) return null;

            return new UserSubscriptionResponseModel
            {
                SubscriptionId = entity.SubscriptionId,
                CreateOn =  entity.CreateOn,
                Id = entity.Id,
                UserId = entity.UserId,
            };

        }

        #endregion

    }
}
