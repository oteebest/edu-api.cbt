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


            builder.Property(u => u.Id)
                    .ValueGeneratedOnAdd();

            builder.HasOne(u => u.DifficultyLevel)
                .WithMany( u => u.Questions)
                .HasForeignKey( u => u.DifficultyLevelId);


            builder.HasOne(u => u.Subject)
                .WithMany(u => u.Questions)
                .HasForeignKey( u => u.SubjectId);

            builder.HasMany(u => u.Options)
                .WithOne(u => u.Question)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
