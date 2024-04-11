namespace Pavas.Abstractions.Exceptions;

[Serializable]
public class EntityNotFoundException(string message) : Exception(message);