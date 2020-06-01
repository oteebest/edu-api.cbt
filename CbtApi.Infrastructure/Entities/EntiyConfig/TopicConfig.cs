using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities.EntiyConfig
{
    public class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
           
        }
    }
}
