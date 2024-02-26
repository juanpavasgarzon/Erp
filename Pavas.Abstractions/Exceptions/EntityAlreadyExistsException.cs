namespace Pavas.Abstractions.Exceptions;

public class EntityAlreadyExistsException(string message) : Exception(message);