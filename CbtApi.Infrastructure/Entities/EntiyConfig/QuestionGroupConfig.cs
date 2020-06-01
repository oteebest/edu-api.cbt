using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities.EntiyConfig
{
    public class QuestionGroupConfig : IEntityTypeConfiguration<QuestionGroup>
    {
        public void Configure(EntityTypeBuilder<QuestionGroup> builder)
        {

        }
    }
}
