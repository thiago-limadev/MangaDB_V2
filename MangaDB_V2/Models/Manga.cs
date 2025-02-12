using System;

public class Manga
{
    [bsonId]
	[BsonRepresentation(Bson.ObjectId)]
    
	public string Id { get; set; } = objectId.GenerateNewId().ToString();
	public string Titulo { get; set; }
	[BsonRepresentation(BsonType.ObjectId)]
	public string AutorId { get; set; }
	public List<string> Arcos { get; set; } = new();
}
