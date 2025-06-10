using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Write;

public class SubmitAccessRequest : ISubmitAccessRequest
{
    public Task<AccessRequest> Execute(Guid userId, Guid vaultId)
    {
        return Task.FromResult(new AccessRequest(vaultId, userId));
    }
}