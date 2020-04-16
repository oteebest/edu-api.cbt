﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities
{
    public class Entity
    {
        public string Id { get; set; }
        public DateTimeOffset CreateOn { get; set; } = DateTimeOffset.Now;
    }
}
