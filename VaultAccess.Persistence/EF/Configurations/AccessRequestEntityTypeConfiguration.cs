using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Persistence.EF.Configurations;

public class AccessRequestEntityTypeConfiguration : IEntityTypeConfiguration<AccessRequest>
{
    public void Configure(EntityTypeBuilder<AccessRequest> builder)
    {
        builder.ToTable("AccessRequests");
        builder.HasKey(accessRequest => new { accessRequest.VaultId, accessRequest.UserId });
        builder.Property(accessRequest => accessRequest.Status).HasConversion<string>().IsRequired();
    }
}