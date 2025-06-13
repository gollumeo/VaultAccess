using FluentAssertions;
using VaultAccess.Application.Write;
using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;

namespace VaultAccess.Tests.Application.UseCases;

public class RejectAccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();

    [Fact]
    public void PendingAccessRequestCanBeRejected()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        var useCase = new RejectAccessRequest();
        var result = useCase.Execute(accessRequest);

        result.IsSuccess.Should().BeTrue();
        accessRequest.Status.Should().Be(AccessRequestStatus.Rejected);
    }

    [Fact]
    public void CannotRejectAnAlreadyRejectedAccessRequest()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        accessRequest.Reject();
        var useCase = new RejectAccessRequest();
        var useCaseExecution = () => useCase.Execute(accessRequest);

        useCaseExecution.Should()
            .ThrowExactly<InvalidAccessRequest>("Cannot reject an already rejected access request.");
    }

    [Fact]
    public void CannotRejectNonPendingAccessRequest()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        accessRequest.Approve();
        var useCase = new RejectAccessRequest();
        var useCaseExecution = () => useCase.Execute(accessRequest);

        useCaseExecution.Should()
            .ThrowExactly<InvalidAccessRequest>("Cannot reject an access request that is not pending.");
    }
}