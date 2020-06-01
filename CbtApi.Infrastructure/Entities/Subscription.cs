using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Subscription : Entity
    {
        public string Name { get; set; }

        public List<UserSubscription> UserSubscriptions { get; set; }

    }
}
