using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Models.ResponseModels
{
    public class SubscriptionResponseModel
    {
        public string Id { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public string Name { get; set; }

    }
}
