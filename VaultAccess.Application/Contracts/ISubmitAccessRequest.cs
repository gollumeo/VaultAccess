using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface ISubmitAccessRequest
{
    public Task<AccessRequest> Execute(Guid userId, Guid vaultId);
}