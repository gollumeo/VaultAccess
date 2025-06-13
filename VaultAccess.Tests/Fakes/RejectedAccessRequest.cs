using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;

namespace VaultAccess.Tests.Fakes;

public class RejectedAccessRequest(Guid vaultId, Guid userId) : AccessRequest(vaultId, userId)
{
    public new AccessRequestStatus Status { get; private set; } = AccessRequestStatus.Rejected;
    public new Guid VaultId { get; } = vaultId;
    public new Guid UserId { get; } = userId;
}