namespace ProjectATM.Models;

public class AutomatedTellerMachine
{
    public int Id { get; set; }
    public string Location { get; set; }
    public Dictionary<int, int> Bills { get; set; }
}
