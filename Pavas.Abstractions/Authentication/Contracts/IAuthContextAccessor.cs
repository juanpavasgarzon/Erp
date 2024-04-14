namespace Pavas.Abstractions.Authentication.Contracts;

public interface IAuthContextAccessor
{
    public IAuthenticable? Auth { get; set; }
}