using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class DifficultyLevel : Entity
    {
        public string Name { get; set; }

        public List<Question> Questions { get; set; }

    }
}
