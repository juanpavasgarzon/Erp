using Pavas.Abstractions.Authentication.Contracts;

namespace Pavas.Abstractions.Authentication;

public class Auth : IAuthenticable
{
    public required int Id { get; set; }
    public required string Username { get; set; }
}