namespace VaultAccess.Domain.Entities;

public class AccessRequest(Guid vaultId, Guid userId)
{
    public Guid VaultId { get; } = vaultId;
    public Guid UserId { get; } = userId;

    public string Status { get; set; } = "pending";
}