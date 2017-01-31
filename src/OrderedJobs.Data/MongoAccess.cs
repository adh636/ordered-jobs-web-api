using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

public interface IDataAccess {
    IEnumerable<TestCase> GetAllTestCases();
    void InsertOneTestCase(TestCase testCase);
    void DeleteAllTestCases();
}
public class MongoAccess: IDataAccess {

    IMongoCollection<TestCase> testCaseCollection;
    public MongoAccess(IMongoClient client)
    {
        var database = client.GetDatabase("orderedjobs");
        testCaseCollection = database.GetCollection<TestCase>("testcases");
    }

    public void DeleteAllTestCases()
    {
        var filter = new BsonDocument();
        testCaseCollection.DeleteManyAsync(filter);
    }

    public IEnumerable<TestCase> GetAllTestCases() {
        return testCaseCollection.Find(x => true).ToListAsync().Result;
    }

    public void InsertOneTestCase(TestCase testCase) {
        testCaseCollection.InsertOneAsync(testCase);
    }
}
