namespace LudumDare54.API.Models.DTO;

public class HighScoreModel : IHighScore
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double TimeTaken { get; set; }
    public DateTime TimeElapsed { get; set; }
}