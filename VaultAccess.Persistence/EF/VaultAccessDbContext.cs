using Microsoft.EntityFrameworkCore;
using VaultAccess.Persistence.EF.Configurations;
using VaultAccess.Persistence.EF.Models;

namespace VaultAccess.Persistence.EF;

public class VaultAccessDbContext(DbContextOptions<VaultAccessDbContext> options) : DbContext(options)
{
    public DbSet<AccessRequestModel> AccessRequests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccessRequestEntityTypeConfiguration());
    }
}