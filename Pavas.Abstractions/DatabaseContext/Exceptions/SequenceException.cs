namespace Pavas.Abstractions.DatabaseContext.Exceptions;

public class SequenceException : Exception
{
    public SequenceException(string? message)
        : base(message)
    {
    }

    public SequenceException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}