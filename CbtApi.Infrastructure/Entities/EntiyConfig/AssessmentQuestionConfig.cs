using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities.EntiyConfig
{
    public class AssessmentQuestionConfig : IEntityTypeConfiguration<AssessmentQuestion>
    {
        public void Configure(EntityTypeBuilder<AssessmentQuestion> builder)
        {
            builder.HasIndex(u => new { u.AssessmentId, u.QuestionId })
                .IsUnique();
                
        }
    }
}
