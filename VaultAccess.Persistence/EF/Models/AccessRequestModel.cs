namespace VaultAccess.Persistence.EF.Models;

public class AccessRequestModel
{
    public Guid Id { get; set; }
    public Guid VaultId { get; set; }
    public Guid UserId { get; set; }
    public string Status { get; set; } = null!;
}