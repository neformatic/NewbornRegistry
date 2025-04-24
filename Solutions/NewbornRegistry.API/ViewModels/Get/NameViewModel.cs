namespace NewbornRegistry.API.ViewModels.Get;

public class NameViewModel
{
    public Guid Id { get; set; }
    public string Use { get; set; }
    public string Family { get; set; }
    public List<string> Given { get; set; }
}