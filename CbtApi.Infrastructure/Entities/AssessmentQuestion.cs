using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class AssessmentQuestion : Entity
    {
        public Assessment Assessment { get; set; }

        public string AssessmentId { get; set; }

        public Question Question { get; set; }

        public string QuestionId { get; set; }
    }
}
