using Application;
using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Write;

public class ApproveAccessRequest : IApproveAccessRequest
{
    public Task<Result<AccessRequest>> Execute(AccessRequest accessRequest)
    {
        accessRequest.Approve();
        return Task.FromResult(Result<AccessRequest>.Success(accessRequest));
    }
}