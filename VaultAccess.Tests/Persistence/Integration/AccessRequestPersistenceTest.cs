using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;
using VaultAccess.Infrastructure.Repositories;
using VaultAccess.Persistence.EF;

namespace VaultAccess.Tests.Persistence.Integration;

public class AccessRequestPersistenceTest : IDisposable, IAsyncDisposable
{
    private readonly AccessRequests _accessRequests;
    private readonly VaultAccessDbContext _dbContext;

    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();

    public AccessRequestPersistenceTest()
    {
        var options = new DbContextOptionsBuilder<VaultAccessDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _dbContext = new VaultAccessDbContext(options);
        _accessRequests = new AccessRequests(_dbContext);
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.DisposeAsync();
    }

    public void Dispose()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }

    [Fact]
    public void CanSaveAccessRequestUponCreation()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);

        _accessRequests.Add(accessRequest);

        var fromDb = _accessRequests.GetById(accessRequest.Id);

        fromDb.Should().NotBeNull();
        fromDb!.Id.Should().Be(accessRequest.Id);
        fromDb!.VaultId.Should().Be(_vaultId);
        fromDb!.UserId.Should().Be(_userId);
        fromDb!.Status.Should().Be(AccessRequestStatus.Pending);
    }

    [Fact]
    public void PersistedAccessRequestRetainsInitialValues()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        _accessRequests.Add(accessRequest);
        var fromDb = _accessRequests.GetById(accessRequest.Id);

        fromDb!.Id.Should().Be(accessRequest.Id);
        fromDb!.Status.Should().Be(accessRequest.Status);
        fromDb!.VaultId.Should().Be(accessRequest.VaultId);
        fromDb!.UserId.Should().Be(accessRequest.UserId);
    }

    [Fact]
    public void CanGetListOfAccessRequests()
    {
        for (var i = 0; i < 10; i++)
            _accessRequests.Add(new AccessRequest(_vaultId, _userId));

        _accessRequests.Add(
            new AccessRequest(_vaultId, Guid.NewGuid())
        );

        var accessRequests = _accessRequests.ListForUser(_userId);

        accessRequests.Should().HaveCount(10);
        accessRequests.Should().AllBeOfType<AccessRequest>();
    }
}