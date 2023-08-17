using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserInformation> UsersInformation { get; set; }
    public DbSet<BoxSaving> BoxSavings { get; set; }
    public DatabaseFacade Database => this.Database;
    public ApplicationDbContext() : base() { }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseNpgsql();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddConfiguration();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = base.ChangeTracker.Entries()
            .Where(CheckEntityState());

        foreach (var entry in entries)
        {
            CheckEntityStatus(entry, entry.Entity);
        }

        return base.SaveChangesAsync();
    }

    private static void CheckEntityStatus(EntityEntry entry, object entity)
    {
        var entityType = entity.GetType();
        if (entry.State == EntityState.Added)
        {
            var createdAtProperty = entityType.GetProperty("CreatedAt");
            createdAtProperty?.SetValue(entity, DateTime.UtcNow);
        }
        if (entry.State == EntityState.Modified)
        {
            var updatedAtProperty = entityType.GetProperty("UpdateAt");
            updatedAtProperty?.SetValue(entity, DateTime.UtcNow);
        }
    }

    private static Func<EntityEntry, bool> CheckEntityState()
    {
        return e => e.State is EntityState.Added
                    || e.State is EntityState.Modified;
    }
}
