using MongoDB.Bson.Serialization.Attributes;

namespace LudumDare54.API.Models;

public interface IIdentifiable
{
    public string Id { get; set; }
}

public class Resource : IIdentifiable
{
    [BsonId]
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public long Version { get; set; }

    public Resource()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
        SetVersion();
    }
    
    public void SetVersion()
    {
        Version = DateTime.UtcNow.Ticks;
    }
}