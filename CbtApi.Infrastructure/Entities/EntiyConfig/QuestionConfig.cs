using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities.EntiyConfig
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(u => u.QuestionType)
             .IsRequired()
             .HasMaxLength(50);

            builder.HasOne(u => u.Topic)
                .WithMany(u => u.Questions)
                .HasForeignKey(u => u.TopicId)
                .IsRequired();


            builder.HasOne(u => u.QuestionGroup)
                .WithMany(u => u.Questions)
                .HasForeignKey(u => u.QuestionGroupId)
                .IsRequired();
        }
    }
}
