using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.Common.Exceptions;

public class EntityNotFoundException : Exception
{
    public BadRequestMessageLevel MessageLevel { get; set; }

    public EntityNotFoundException(string message, BadRequestMessageLevel level = BadRequestMessageLevel.Error) : base(message)
    {
        MessageLevel = level;
    }
}