using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.BLL.Models.Update;

public class UpdatePatientModel
{
    public UpdateNameModel Name { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
}