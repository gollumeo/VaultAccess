using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface IApproveAccessRequest
{
    public void Execute(AccessRequest accessRequest);
}