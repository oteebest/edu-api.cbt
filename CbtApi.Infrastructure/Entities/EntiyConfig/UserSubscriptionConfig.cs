using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Infrastructure.Entities.EntiyConfig
{
    public class UserSubscriptionConfig : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            builder.HasIndex(u => new { u.UserId, u.SubscriptionId }).IsUnique();
        }
    }
}
