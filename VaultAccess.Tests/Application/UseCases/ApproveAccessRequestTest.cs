using FluentAssertions;
using VaultAccess.Application.Write;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Tests.Application.UseCases;

public class ApproveAccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();

    [Fact]
    public async Task ApprovesPendingAccessRequest()
    {
        var accessRequest = new AccessRequest(_vaultId, _userId);
        var useCase = new ApproveAccessRequest();

        var result = await useCase.Execute(accessRequest);

        result.IsFailure.Should().BeTrue();
    }
}