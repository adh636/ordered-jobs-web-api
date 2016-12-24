using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class TestCase {
    public string testCase {get; set;}
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get; set;}
}