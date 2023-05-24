using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserInformationConfiguration : IEntityTypeConfiguration<UserInformation>
{
    public void Configure(EntityTypeBuilder<UserInformation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.value, x => new UserInformationId(x));


        builder.Property(x => x.FirstName).HasMaxLength(128);

        builder.Property(x => x.LastName).HasMaxLength(128);

        builder.Property(x => x.Address).HasMaxLength(500);

        builder.Property(x => x.PhoneNumber).HasMaxLength(35);

        
    }
}
