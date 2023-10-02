namespace LudumDare54.API.Models;

public interface IHighScore : IIdentifiable
{
    string Name { get; set; }
    double TimeTaken { get; set; } 
    DateTime TimeFinished { get; set; }
    int Items { get; set; }
}

public class HighScore : Resource, IHighScore
{
    public string Name { get; set; }
    public double TimeTaken { get; set; }
    public DateTime TimeFinished { get; set; }
    public int Items { get; set; }
}