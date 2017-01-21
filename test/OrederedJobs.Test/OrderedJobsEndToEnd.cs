using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class OrderedJobsEndToEnd {

    HttpClient httpClient;
    
    [SetUp]
	public void InitializeOrderedJobsClass()
	{
        httpClient = new HttpClient();
	}

    [Test]
    public async Task NoTestCases() {
        var expected = "{\"testCaseResults\":[],\"result\":\"PASS\"}";
        
        await httpClient.DeleteAsync("http://localhost:5000/api/test");
        
        var response = await httpClient.GetAsync("http://localhost:5000/api/test"); 
        var result = await response.Content.ReadAsStringAsync();

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public async Task OneTestCase() {
        var expected =  "{\"testCaseResults\":[{\"permutationResults\":[{\"testCase\":" + 
        "\"a-|b-\",\"result\":\"PASS\"},{\"testCase\":\"b-|a-\",\"result\":\"PASS\"}]" + 
        ",\"testCase\":\"a-|b-\",\"result\":\"PASS\"}],\"result\":\"PASS\"}";
        
        var testCase = new
        {
            testCase = "a-|b-"
        };
        
        await httpClient.DeleteAsync("http://localhost:5000/api/test");
        await httpClient.PostAsJsonAsync("http://localhost:5000/api/test", testCase);

        var response = await httpClient.GetAsync("http://localhost:5000/api/test?url=http://localhost:5000/api/orderedJobs"); 
        var result = await response.Content.ReadAsStringAsync();

        Assert.That(result, Is.EqualTo(expected));
    }
}