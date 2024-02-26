namespace Pavas.API.MinimalApi.Contracts;

public interface IEndpoint
{
    void Configure(IEndpointRouteBuilder endpoints);
}