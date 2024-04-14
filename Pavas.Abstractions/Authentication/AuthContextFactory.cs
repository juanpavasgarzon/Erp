using Pavas.Abstractions.Authentication.Contracts;

namespace Pavas.Abstractions.Authentication;

public class AuthContextFactory : IAuthContextFactory
{
    private readonly IAuthContextAccessor _authContextAccessor;

    public AuthContextFactory(IAuthContextAccessor authContextAccessor)
    {
        _authContextAccessor = authContextAccessor;
    }

    public void Create(int id, string username)
    {
        _authContextAccessor.Auth = new Auth
        {
            Id = id,
            Username = username
        };
    }
}