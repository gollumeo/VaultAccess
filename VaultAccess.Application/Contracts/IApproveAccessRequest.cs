using Application;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface IApproveAccessRequest
{
    public Result<AccessRequest> Execute(AccessRequest accessRequest);
}