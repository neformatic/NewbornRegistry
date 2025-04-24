using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.BLL.Common;

public class BadRequestException : Exception
{
    public BadRequestMessageLevel MessageLevel { get; set; }

    public BadRequestException(string message, BadRequestMessageLevel level = BadRequestMessageLevel.Error) : base(message)
    {
        MessageLevel = level;
    }
}