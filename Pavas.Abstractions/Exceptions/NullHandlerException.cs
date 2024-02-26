using System.Runtime.Serialization;

namespace Pavas.Abstractions.Exceptions;

[Serializable]
public class NullHandlerException : Exception
{
    public NullHandlerException(string message)
        : base(message)
    {
    }

    public NullHandlerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    [Obsolete("Obsolete")]
    protected NullHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}