using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Infrastructure.Repositories;

public class AccessRequests :IAccessRequestRepository
{
    public AccessRequest? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Save(AccessRequest accessRequest)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AccessRequest> ListForUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}