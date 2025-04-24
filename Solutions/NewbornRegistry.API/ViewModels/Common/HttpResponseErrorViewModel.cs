using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.API.ViewModels.Common;

public class HttpResponseErrorViewModel
{
    public string ErrorMessage { get; set; }
    public BadRequestMessageLevel ErrorMessageLevel { get; set; }
}