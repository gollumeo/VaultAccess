using Application;
using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Write;

public class ApproveAccessRequest : IApproveAccessRequest
{
    public Result<AccessRequest> Execute(AccessRequest accessRequest)
    {
        accessRequest.Approve();
        return Result<AccessRequest>.Success(accessRequest);
    }
}