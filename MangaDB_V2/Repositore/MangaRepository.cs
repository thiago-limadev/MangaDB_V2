using MongoDB.Driver;

public class MangaRepository
{
    private readonly IMongoCollection<Manga> _mangas;

    public MangaRepository(MongoDBService dbService)
    {
        _mangas = dbService.GetCollection<Manga>("Mangas");
    }

    public async Task<List<Manga>> GetAllAsync() => await _mangas.Find(m => true).ToListAsync();

    public async Task<Manga> GetByIdAsync(string id) =>
        await _mangas.Find(m => m.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Manga manga) =>
        await _mangas.InsertOneAsync(manga);

    public async Task UpdateAsync(string id, Manga manga) =>
        await _mangas.ReplaceOneAsync(m => m.Id == id, manga);

    public async Task DeleteAsync(string id) =>
        await _mangas.DeleteOneAsync(m => m.Id == id);
}
