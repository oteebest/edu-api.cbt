using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Assessment : Entity
    {
        public string Name { get; set; }

        public string Instructions { get; set; }

        public string UserId { get; set; }
        public int Duration { get;  set; }
    }
}
