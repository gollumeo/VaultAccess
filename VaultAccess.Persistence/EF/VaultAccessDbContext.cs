using Microsoft.EntityFrameworkCore;
using VaultAccess.Domain.Entities;
using VaultAccess.Persistence.EF.Configurations;

namespace VaultAccess.Persistence.EF;

public class VaultAccessDbContext(DbContextOptions<VaultAccessDbContext> options) : DbContext(options)
{
    private DbSet<AccessRequest> AccessRequests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccessRequestEntityTypeConfiguration());
    }
}