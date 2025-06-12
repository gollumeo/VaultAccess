using Application;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface IApproveAccessRequest
{
    public Task<Result<AccessRequest>> Execute(AccessRequest accessRequest);
}