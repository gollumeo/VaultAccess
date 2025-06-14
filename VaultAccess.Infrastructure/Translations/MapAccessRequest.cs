using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;
using VaultAccess.Persistence.EF.Models;

namespace VaultAccess.Infrastructure.Translations;

public static class MapAccessRequest
{
    public static AccessRequestModel ToModel(AccessRequest domain)
    {
        return new AccessRequestModel
        {
            Id = domain.Id,
            VaultId = domain.VaultId,
            UserId = domain.UserId,
            Status = domain.Status.ToString()
        };
    }

    public static AccessRequest ToDomain(AccessRequestModel model)
    {
        var entity = new AccessRequest(model.VaultId, model.UserId);
        typeof(AccessRequest)
            .GetProperty("Id")!
            .SetValue(entity, model.Id);

        if (Enum.TryParse<AccessRequestStatus>(model.Status, out var status)
            && status != AccessRequestStatus.Pending)
            typeof(AccessRequest)
                .GetProperty("Status")!
                .SetValue(entity, status);

        return entity;
    }
}