using System.Reflection;
using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;

namespace VaultAccess.Tests.Factory;

public static class AccessRequestFakeFactory
{
    public static AccessRequest WithStatus(Guid vaultId, Guid userId, AccessRequestStatus status)
    {
        var request = (AccessRequest)Activator.CreateInstance(
            typeof(AccessRequest),
            true
        )!;

        typeof(AccessRequest).GetField("<VaultId>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(request, vaultId);

        typeof(AccessRequest).GetField("<UserId>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(request, userId);

        typeof(AccessRequest).GetField("<Status>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(request, status);

        return request;
    }
}