using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.BLL.Models.Get;

public class PatientModel
{
    public NameModel Name { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
}