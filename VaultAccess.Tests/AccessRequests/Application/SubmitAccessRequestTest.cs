using FluentAssertions;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Tests.AccessRequests.Application;

public class SubmitAccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    
    [Fact]
    public void AccessRequestIsCreatedUponUserRequest()
    {
        var accessRequest = new AccessRequest(Guid.NewGuid(), _userId);

        accessRequest.Should().BeOfType<AccessRequest>();
    }

    [Fact]
    public void UserCanSubmitRequestToSpecificVault()
    {
        var vaultId = Guid.Empty;
        var accessRequest = new AccessRequest(vaultId, _userId);

        accessRequest.VaultId.Should().Be(vaultId);
    }

    [Fact]
    public void AccessRequestMustBePendingUponCreation()
    {
        var accessRequest = new AccessRequest(Guid.Empty, _userId);
        
        accessRequest.Status.Should().Be("pending");
    }

    [Fact]
    public void AccessRequestMustBeLinkedToUser()
    {
        var accessRequest = new AccessRequest(Guid.Empty, _userId);
        
        accessRequest.UserId.Should().Be(_userId);
    }
}