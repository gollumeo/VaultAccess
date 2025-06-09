namespace VaultAccess.Domain.Entities;

public class AccessRequest(Guid vaultId)
{
    public Guid VaultId { get; } = vaultId;

    public string Status { get; set; } = "pending";
}