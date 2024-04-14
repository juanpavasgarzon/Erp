using Pavas.Abstractions.Authentication.Contracts;

namespace Pavas.Abstractions.Authentication;

public class AuthContextAccessor : IAuthContextAccessor
{
    public IAuthenticable? Auth { get; set; }
}