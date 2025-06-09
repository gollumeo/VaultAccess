using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Write;

public class SubmitAccessRequest : ISubmitAccessRequest
{
    public Task<AccessRequest> Execute()
    {
        throw new NotImplementedException();
    }
}