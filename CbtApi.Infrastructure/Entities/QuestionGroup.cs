using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class QuestionGroup : Entity
    {
        public List<Question> Questions { get; set; }
    }
}
