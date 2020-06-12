using CbtApi.Infrastructure.Entities;
using CbtApi.Infrastructure.Entities.EntiyConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AssessmentConfig());
            modelBuilder.ApplyConfiguration(new AssessmentQuestionConfig());
            modelBuilder.ApplyConfiguration(new QuestionConfig());
            modelBuilder.ApplyConfiguration(new OptionConfig());
            modelBuilder.ApplyConfiguration(new DifficultyLevelConfig());
            modelBuilder.ApplyConfiguration(new SubjectConfig());
        }
    }
}
