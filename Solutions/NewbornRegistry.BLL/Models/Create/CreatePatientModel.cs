using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.BLL.Models.Create;

public class CreatePatientModel
{
    public CreateNameModel Name { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
}