namespace NewbornRegistry.BLL.Models.Update;

public class UpdateNameModel
{
    public Guid Id { get; set; }
    public string Use { get; set; }
    public string Family { get; set; }
    public List<string> Given { get; set; }
}