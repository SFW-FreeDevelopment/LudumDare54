namespace LudumDare54.API.Models.DTO;

public class HighScoreModel : IHighScore
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double TimeTaken { get; set; }
    public DateTime TimeFinished { get; set; }
    public int Items { get; set; }
}