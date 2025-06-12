using FluentAssertions;
using VaultAccess.Application.Write;
using VaultAccess.Domain.Entities;
using VaultAccess.Domain.Enums;
using VaultAccess.Domain.Exceptions;

namespace VaultAccess.Tests.Application.UseCases;

public class ApproveAccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();

    [Fact]
    public void PendingAccessRequestShouldBeGranted()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        var useCase = new ApproveAccessRequest();

        var result = useCase.Execute(accessRequest);

        result.IsSuccess.Should().BeTrue();
        accessRequest.Status.Should().Be(AccessRequestStatus.Granted);
    }

    [Fact]
    public void CannotGrantAccessMultipleTimes()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        var useCase = new ApproveAccessRequest();

        useCase.Execute(accessRequest);
        var approvalConstruction = () => useCase.Execute(accessRequest);

        approvalConstruction.Should()
            .ThrowExactly<InvalidAccessRequest>("Access request already granted.");
    }
}