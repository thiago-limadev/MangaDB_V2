using System;
using MongoDB.Driver;

public class AutorRepository
{
	private readonly IMongoCollection<Autor> _autores;

	public AutorRepository(MongoDbService dbService)
	{
		_autores = dbService.GetCollection<Autor>("Autores");
	}

	public async Task<List<Autor>> GetAllAsync() => await _autores.Find(a => true).ToListAsync();

	public async Task CreateAsync(Autor autor) => await _autores.Insert(autor);

	public async Task UpdateAsync(string id, Autor autor) => await _autores.ReplaceOneSync(a =>  a.Id == id,autor);

	public async Task DeleteAsync(string id) => await _autores.DeleteOneAsync(a => a.Id == id);
		
}