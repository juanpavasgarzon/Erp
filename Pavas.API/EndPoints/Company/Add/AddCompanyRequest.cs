namespace Pavas.API.EndPoints.Company.Add;

public record AddCompanyRequest(
    int Id,
    string Name,
    string Industry,
    DateTime FoundedDate
);