using FluentAssertions;
using VaultAccess.Application.Write;
using VaultAccess.Domain.Entities;

namespace VaultAccess.Tests.Application.UseCases;

public class SubmitAccessRequestTest
{
    private readonly Guid _userId = Guid.NewGuid();
    private readonly Guid _vaultId = Guid.NewGuid();
    
    [Fact]
    public async Task ReturnsAccessRequest()
    {
        var useCase = new SubmitAccessRequest();
        var result = await useCase.Execute(_userId, _vaultId);

        result.Should().BeOfType<AccessRequest>();
    }

    [Fact]
    public async Task ReturnedAccessRequestShouldBePending()
    {
        var useCase = new SubmitAccessRequest();
        var result = await useCase.Execute(_userId, _vaultId);
        
        result.Status.Should().Be("pending");
    }

    [Fact]
    public async Task ReturnedAccessRequestShouldBeLinkedToCorrectUser()
    {
        var useCase = new SubmitAccessRequest();
        var result = await useCase.Execute(_userId, _vaultId);
        
        result.UserId.Should().Be(_userId);
    }
    
    [Fact]
    public async Task ReturnedAccessRequestShouldBeLinkedToCorrectVault()
    {
        var useCase = new SubmitAccessRequest();
        var result = await useCase.Execute(_userId, _vaultId);
        
        result.VaultId.Should().Be(_vaultId);
    }
}