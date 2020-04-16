using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Option : Entity
    {
        public bool IsAnswer { get; set; }

        public string Text { get; set; }

        public string QuestionId { get; set; }

        public Question Question { get; set; }

       
    }
}
