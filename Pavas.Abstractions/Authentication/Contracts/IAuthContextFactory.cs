namespace Pavas.Abstractions.Authentication.Contracts;

public interface IAuthContextFactory
{
   public void Create(int id, string username);
}