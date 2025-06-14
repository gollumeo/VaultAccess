using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaultAccess.Persistence.EF.Models;

namespace VaultAccess.Persistence.EF.Configurations;

public class AccessRequestEntityTypeConfiguration : IEntityTypeConfiguration<AccessRequestModel>
{
    public void Configure(EntityTypeBuilder<AccessRequestModel> builder)
    {
        builder.ToTable("AccessRequests");

        builder.HasKey(accessRequest => new { accessRequest.VaultId, accessRequest.UserId });
        builder.HasKey(accessRequest => accessRequest.Id);

        builder.HasIndex(accessRequest => new { accessRequest.VaultId, accessRequest.UserId }).IsUnique();

        builder.Property(accessRequest => accessRequest.Status).HasConversion<string>().IsRequired();
    }
}