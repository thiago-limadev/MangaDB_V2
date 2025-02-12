using System;

public class Arco
{
	[bsonId]
	[BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = objectId.GenerateNewId().ToString();	
   
	public string Nome {  get; set; }
	public int QuantidadedeCapitulos { get; set; }
	[BsonRepresentation(BsonType.ObjectId)]
	public string MangaId { get; set; }
}
