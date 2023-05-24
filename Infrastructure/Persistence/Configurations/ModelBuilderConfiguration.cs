using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

internal static class ModelBuilderConfiguration
{
    public static ModelBuilder AddConfiguration(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Saving>().HasNoKey();
        modelBuilder.Ignore<Saving>();

        return modelBuilder;
    }
}
