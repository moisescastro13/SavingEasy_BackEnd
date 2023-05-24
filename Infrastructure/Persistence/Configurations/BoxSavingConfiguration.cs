
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;

namespace Infrastructure.Persistence.Configurations;

public class BoxSavingConfiguration : IEntityTypeConfiguration<BoxSaving>
{
    public void Configure(EntityTypeBuilder<BoxSaving> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.value, x => new BoxSavingId(x));

        builder.Property(x => x.Total).IsRequired();

       
        builder.Ignore(x => x.savings);

        var converter = new ValueConverter<HashSet<Saving>, string>(
            v => JsonConvert.SerializeObject(v, Formatting.Indented),
            v => JsonConvert.DeserializeObject<HashSet<Saving>>(v ?? "[]"));

        builder.Property<HashSet<Saving>>("_savings")
            .HasColumnName("Savings")
            .HasConversion(converter)
            .HasColumnType("jsonb");

    }
}
