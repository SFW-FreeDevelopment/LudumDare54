namespace LudumDare54.API.Models;

public interface IHighScore : IIdentifiable
{
    string Name { get; set; }
    double TimeTaken { get; set; } 
    DateTime TimeElapsed { get; set; }
}

public class HighScore : Resource, IHighScore
{
    public string Name { get; set; }
    public double TimeTaken { get; set; }
    public DateTime TimeElapsed { get; set; }
}