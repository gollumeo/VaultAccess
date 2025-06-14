using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;
using VaultAccess.Domain.Rules;

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

    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid VaultId { get; }
    public Guid UserId { get; }
    public AccessRequestStatus Status { get; private set; }

    public void Approve()
    {
        AccessRequestRules.EnsureIsApprovable(Status);
        Status = AccessRequestStatus.Granted;
    }

    public void Reject()
    {
        AccessRequestRules.EnsureIsRejectable(Status);
        Status = AccessRequestStatus.Rejected;
    }
}