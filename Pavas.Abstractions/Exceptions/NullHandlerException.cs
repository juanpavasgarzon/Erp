namespace Pavas.Abstractions.Exceptions;

[Serializable]
public class NullHandlerException(string message) : Exception(message);