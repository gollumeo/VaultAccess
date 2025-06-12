using Application;
using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Write;

public class SubmitAccessRequest : ISubmitAccessRequest
{
    public Result<AccessRequest> Execute(Guid userId, Guid vaultId)
    {
        return Result<AccessRequest>.Success(new AccessRequest(vaultId, userId));
    }
}