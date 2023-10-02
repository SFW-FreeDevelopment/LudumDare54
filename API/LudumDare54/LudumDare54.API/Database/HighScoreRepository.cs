using LudumDare54.API.Models;
using MongoDB.Driver;

namespace LudumDare54.API.Database;

public class HighScoreRepository : Repository<HighScore>
{
    public HighScoreRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        CollectionName = "highscores";
    }
}