using LudumDare54.API.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LudumDare54.API.Mongo;

public class Repository<T> where T : Resource
{
    private readonly IMongoClient _mongoClient;
    protected string CollectionName;

    protected Repository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public virtual async Task<List<T>> Get()
    {
        try
        {
            var items = await GetCollection().AsQueryable().Where(x => x != null && !x.Id.Contains("test"))
                .ToListAsync();
            return items;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public virtual async Task<T> Get(string id)
    {
        try
        {
            var item = await GetCollection().AsQueryable()
                .FirstOrDefaultAsync(w => w.Id.Equals(id));
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public virtual async Task<T> Create(T data)
    {
        try
        {
            data.Id ??= Guid.NewGuid().ToString();
            data.CreatedAt = DateTime.UtcNow;
            data.UpdatedAt = data.CreatedAt;
            await GetCollection().InsertOneAsync(data);
            var items = await GetCollection().AsQueryable().ToListAsync();
            return items?.FirstOrDefault(x => x.Id.Equals(data.Id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public virtual async Task<T> Update(string id, T data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        await GetCollection().ReplaceOneAsync(x => x.Id.Equals(id), data);
        return data;
    }

    public virtual async Task Delete(string id)
    {
        try
        {
            await GetCollection().DeleteOneAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private IMongoCollection<T> GetCollection()
    {
        var database = _mongoClient.GetDatabase("main");
        var collection = database.GetCollection<T>(CollectionName);
        return collection;
    }
}