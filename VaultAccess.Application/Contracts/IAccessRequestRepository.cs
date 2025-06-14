using VaultAccess.Domain.Entities;

namespace VaultAccess.Application.Contracts;

public interface IAccessRequestRepository
{
    AccessRequest? GetById(Guid id);
    void Save(AccessRequest accessRequest);
    IEnumerable<AccessRequest> ListForUser(Guid userId);
}