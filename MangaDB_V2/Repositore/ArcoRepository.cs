using MongoDB.Driver;

public class ArcoRepository
{
    private readonly IMongoCollection<Arco> _arcos;

    public ArcoRepository(MongoDBService dbService)
    {
        _arcos = dbService.GetCollection<Arco>("Arcos");
    }

    public async Task<List<Arco>> GetAllAsync() => await _arcos.Find(a => true).ToListAsync();

    public async Task<Arco> GetByIdAsync(string id) =>
        await _arcos.Find(a => a.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Arco arco) =>
        await _arcos.InsertOneAsync(arco);

    public async Task UpdateAsync(string id, Arco arco) =>
        await _arcos.ReplaceOneAsync(a => a.Id == id, arco);

    public async Task DeleteAsync(string id) =>
        await _arcos.DeleteOneAsync(a => a.Id == id);
}
