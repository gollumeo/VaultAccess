using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface IAccessRequestRepository
{
    AccessRequest? GetById(Guid id);
    void Add(AccessRequest accessRequest);
    IEnumerable<AccessRequest> ListForUser(Guid userId);
}