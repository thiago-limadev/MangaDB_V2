using System;

public class Autor
{
    [bsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public int Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public string Nome { get; set; }
	public int Idade { get; set; }
	public List<string> Mangas { get; set; } = new();
}
