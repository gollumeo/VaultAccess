using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;

namespace VaultAccess.Domain.Entities;

public class AccessRequest
{
    public AccessRequest(Guid vaultId, Guid userId)
    {
        if (vaultId == Guid.Empty || userId == Guid.Empty)
            throw new InvalidAccessRequest("Cannot create an access request with no user or vault.");

        VaultId = vaultId;
        UserId = userId;
        Status = AccessRequestStatus.Pending;
    }

    public Guid VaultId { get; }
    public Guid UserId { get; }
    public AccessRequestStatus Status { get; private set; }
}