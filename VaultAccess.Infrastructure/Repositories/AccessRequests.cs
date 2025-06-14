using VaultAccess.Application.Contracts;
using VaultAccess.Domain.Entities;
using VaultAccess.Infrastructure.Translations;
using VaultAccess.Persistence.EF;

namespace VaultAccess.Infrastructure.Repositories;

public class AccessRequests(VaultAccessDbContext dbContext) : IAccessRequestRepository
{
    public AccessRequest? GetById(Guid id)
    {
        var model = dbContext.AccessRequests.FirstOrDefault(x => x.Id == id);

        return model is null
            ? null
            : MapAccessRequest.ToDomain(model);
    }

    public void Add(AccessRequest accessRequest)
    {
        var model = MapAccessRequest.ToModel(accessRequest);

        dbContext.AccessRequests.Add(model);

        dbContext.SaveChanges();
    }

    public IEnumerable<AccessRequest> ListForUser(Guid userId)
    {
        var models = dbContext.AccessRequests.Where(x => x.UserId == userId);

        return models.AsEnumerable()
            .Select(MapAccessRequest.ToDomain).ToList();
    }
}