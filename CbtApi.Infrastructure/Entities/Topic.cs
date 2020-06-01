using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Topic : Entity
    {
        public List<Question> Questions { get; set; }

        public string Name { get; set; }
    }
}
