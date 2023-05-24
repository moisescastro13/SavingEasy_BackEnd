using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.value, x => new UserId(x));

        builder.Property(x => x.UserName).HasMaxLength(128);
        builder.HasIndex(x => x.UserName).IsUnique();

        builder.Property(x => x.Email).HasMaxLength(128);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Password).HasMaxLength(512);

        builder.HasOne(x => x.userInformation)
           .WithOne(x => x.user)
           .HasForeignKey<UserInformation>(x => x.userId);

        builder.HasMany(x => x.BoxSavings)
           .WithOne()
           .HasForeignKey(x => x.userId);
    }
}
