using Application;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface IRejectAccessRequest
{
    public Result<AccessRequest> Execute(AccessRequest accessRequest);
}