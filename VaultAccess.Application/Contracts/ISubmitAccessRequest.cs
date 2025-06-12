using Application;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface ISubmitAccessRequest
{
    public Result<AccessRequest> Execute(Guid userId, Guid vaultId);
}