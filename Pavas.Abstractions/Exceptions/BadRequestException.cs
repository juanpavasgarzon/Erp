namespace Pavas.Abstractions.Exceptions;

[Serializable]
public class BadRequestException(string message) : Exception(message);