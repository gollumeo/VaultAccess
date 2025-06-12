using FluentAssertions;
using VaultAccess.Application.Write;
using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;

namespace VaultAccess.Tests.Application.UseCases;

public class SubmitAccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();

    [Fact]
    public void ReturnsAccessRequest()
    {
        var useCase = new SubmitAccessRequest();
        var result = useCase.Execute(_userId, _vaultId);

        result.Value.Should().BeOfType<AccessRequest>();
    }

    [Fact]
    public void ReturnedAccessRequestShouldBePending()
    {
        var useCase = new SubmitAccessRequest();
        var result = useCase.Execute(_userId, _vaultId);

        result.Value.Status.Should().Be(AccessRequestStatus.Pending);
    }

    [Fact]
    public void ReturnedAccessRequestShouldBeLinkedToCorrectUser()
    {
        var useCase = new SubmitAccessRequest();
        var result = useCase.Execute(_userId, _vaultId);

        result.Value.UserId.Should().Be(_userId);
    }

    [Fact]
    public void ReturnedAccessRequestShouldBeLinkedToCorrectVault()
    {
        var useCase = new SubmitAccessRequest();
        var result = useCase.Execute(_userId, _vaultId);

        result.Value.VaultId.Should().Be(_vaultId);
    }

    [Fact]
    public void CannotSubmitAccessRequestWithNoUser()
    {
        var emptyUserId = Guid.Empty;
        var useCase = new SubmitAccessRequest();
        var useCaseExecution = () => useCase.Execute(emptyUserId, _vaultId);

        useCaseExecution.Should()
            .ThrowExactly<InvalidAccessRequest>("Cannot create an access request with no user or vault.");
    }
}