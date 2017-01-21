
using System.Collections.Generic;
using MongoDB.Driver;

public interface IDataAccess {
    IEnumerable<TestCase> GetAllTestCases();
}
public class MongoAccess: IDataAccess {

    IMongoCollection<TestCase> testCaseCollection;
    public MongoAccess(IMongoClient client)
    {
        var database = client.GetDatabase("orderedjobs");
        testCaseCollection = database.GetCollection<TestCase>("testcases");
    }
    public IEnumerable<TestCase> GetAllTestCases() {
        return testCaseCollection.Find(x => true).ToListAsync().Result;
    }
}
