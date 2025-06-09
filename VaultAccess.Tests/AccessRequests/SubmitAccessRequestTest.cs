using FluentAssertions;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Tests.AccessRequests;

public class SubmitAccessRequestTest
{
    [Fact]
    public void AccessRequestIsCreatedUponUserRequest()
    {
        var accessRequest = new AccessRequest(Guid.Empty);

        accessRequest.Should().BeOfType<AccessRequest>();
    }

    [Fact]
    public void UserCanSubmitRequestToSpecificVault()
    {
        var vaultId = Guid.Empty;
        var accessRequest = new AccessRequest(vaultId);

        accessRequest.VaultId.Should().Be(vaultId);
    }

    [Fact]
    public void AccessRequestMustBePendingUponCreation()
    {
        var accessRequest = new AccessRequest(Guid.Empty);
        
        accessRequest.Status.Should().Be("pending");
    }
}