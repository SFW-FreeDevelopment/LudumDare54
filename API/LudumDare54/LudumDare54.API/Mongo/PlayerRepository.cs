using LudumDare54.API.Models;
using MongoDB.Driver;

namespace LudumDare54.API.Mongo;

public class PlayerRepository : Repository<Player>
{
    public PlayerRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        CollectionName = "players";
    }
}