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

    /// <summary>
    ///     🚧For testing purposes only 🚧
    /// </summary>
    private AccessRequest()
    {
    }

    public Guid VaultId { get; }
    public Guid UserId { get; }
    public AccessRequestStatus Status { get; private set; }

    public void Approve()
    {
        if (Status == AccessRequestStatus.Granted)
            throw new InvalidAccessRequest("Access request already granted.");

        if (Status != AccessRequestStatus.Pending)
            throw new InvalidAccessRequest("Cannot grant access to a non-pending access request.");

        Status = AccessRequestStatus.Granted;
    }

    public void Reject()
    {
        if (Status == AccessRequestStatus.Rejected)
            throw new InvalidAccessRequest("Access request already rejected.");

        if (Status != AccessRequestStatus.Pending)
            throw new InvalidAccessRequest("Cannot reject a non-pending access request.");

        Status = AccessRequestStatus.Rejected;
    }
}