using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;

namespace VaultAccess.Domain.Rules;

public static class AccessRequestRules
{
    public static void EnsureIsApprovable(AccessRequestStatus status)
    {
        if (status == AccessRequestStatus.Granted)
            throw new InvalidAccessRequest("Access request already granted.");

        if (status != AccessRequestStatus.Pending)
            throw new InvalidAccessRequest("Cannot grant access to a non-pending access request.");
    }

    public static void EnsureIsRejectable(AccessRequestStatus status)
    {
        if (status == AccessRequestStatus.Rejected)
            throw new InvalidAccessRequest("Access request already rejected.");

        if (status != AccessRequestStatus.Pending)
            throw new InvalidAccessRequest("Cannot reject a non-pending access request.");
    }
}