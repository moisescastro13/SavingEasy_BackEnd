
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<UserInformation> UsersInformation { get; set; }
    DbSet<BoxSaving> BoxSavings { get; set; }
    DatabaseFacade Database { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
