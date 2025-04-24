namespace NewbornRegistry.API.ViewModels.Get;

public class PatientViewModel
{
    public NameViewModel Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
}