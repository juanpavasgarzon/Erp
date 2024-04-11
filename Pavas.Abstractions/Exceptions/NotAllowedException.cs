namespace Pavas.Abstractions.Exceptions;

[Serializable]
public class NotAllowedException(string message) : Exception(message);