using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.DAL.Entities;

public class Patient
{
    public Patient()
    {
        Given = new List<string>();
    }

    public Guid Id { get; set; }
    public string Use { get; set; }
    public string Family { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
    public List<string> Given { get; set; }
}