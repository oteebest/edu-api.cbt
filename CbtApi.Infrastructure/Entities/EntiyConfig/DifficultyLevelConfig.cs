using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities.EntiyConfig
{
    public class DifficultyLevelConfig : IEntityTypeConfiguration<DifficultyLevel>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
        {
            builder.Property(u => u.Id)
                 .ValueGeneratedOnAdd();
        }
    }
}
