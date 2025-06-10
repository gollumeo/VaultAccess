using FluentAssertions;
using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;

namespace VaultAccess.Tests.Domain.Entities;

public class AccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();

    [Fact]
    public void AccessRequestIsCreatedUponUserRequest()
    {
        var accessRequest = new AccessRequest(Guid.NewGuid(), _userId);

        accessRequest.Should().BeOfType<AccessRequest>();
    }

    [Fact]
    public void UserCanSubmitRequestToSpecificVault()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);

        accessRequest.VaultId.Should().Be(_vaultId);
    }

    [Fact]
    public void AccessRequestMustBePendingUponCreation()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);

        accessRequest.Status.Should().Be(AccessRequestStatus.Pending);
    }

    [Fact]
    public void AccessRequestMustBeLinkedToUser()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);

        accessRequest.UserId.Should().Be(_userId);
    }

    [Fact]
    public void AccessRequestCannotBeCreatedWithNoUser()
    {
        var accessRequestCreation = () => new AccessRequest(Guid.Empty, Guid.NewGuid());

        accessRequestCreation.Should().ThrowExactly<InvalidAccessRequest>();
    }

    [Fact]
    public void AccessRequestCannotBeCreatedWithNoVault()
    {
        var accessRequestCreation = () => new AccessRequest(Guid.NewGuid(), Guid.Empty);

        accessRequestCreation.Should().ThrowExactly<InvalidAccessRequest>();
    }

    [Fact]
    public void AccessRequestCannotBeCreatedWithNoUserAndNoVault()
    {
        var accessRequestCreation = () => new AccessRequest(Guid.Empty, Guid.Empty);

        accessRequestCreation.Should().ThrowExactly<InvalidAccessRequest>();
    }
}