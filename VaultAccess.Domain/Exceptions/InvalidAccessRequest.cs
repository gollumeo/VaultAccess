namespace VaultAccess.Domain.Exceptions;

public class InvalidAccessRequest(string message) : Exception(message)
{
    
}