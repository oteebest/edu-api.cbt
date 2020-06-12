using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Models.ResponseModels
{
    public class UserSubscriptionResponseModel
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public string UserId { get; set; }
        public string SubscriptionId { get; set; }
    }
}
