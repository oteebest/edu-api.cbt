using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class UserSubscription : Entity
    {
        public string UserId { get; set; }

        public string SubscriptionId { get; set; }

        public bool IsDefault { get; set; }

        public Subscription Subscription { get; set; }
    }
}
