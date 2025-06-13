using Application;
using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Write;

public class RejectAccessRequest : IRejectAccessRequest
{
    public Result<AccessRequest> Execute(AccessRequest accessRequest)
    {
        accessRequest.Reject();

        return Result<AccessRequest>.Success(accessRequest);
    }
}