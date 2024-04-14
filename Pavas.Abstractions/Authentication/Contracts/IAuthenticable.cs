namespace Pavas.Abstractions.Authentication.Contracts;

public interface IAuthenticable
{
    public int Id { get; }
    public string Username { get; }
}
