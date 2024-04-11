namespace Pavas.Abstractions.Exceptions;

[Serializable]
public class EntityAlreadyExistsException(string message) : Exception(message);