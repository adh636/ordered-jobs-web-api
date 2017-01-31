using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class OrderedJobsEndToEnd {

    HttpClient httpClient;
    String url = "http://localhost:5000/api/test";
    
    [SetUp]
	public void InitializeOrderedJobsClass()
	{
        httpClient = new HttpClient();
	}

    [Test]
    public async Task NoTestCases() {
        var expected = "{\"testCaseResults\":[],\"result\":\"PASS\"}";
        
        await httpClient.DeleteAsync(url);
        
        var response = await httpClient.GetAsync(url); 
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
        
        await httpClient.DeleteAsync(url);
        await httpClient.PostAsJsonAsync(url, testCase);

        var response = await httpClient.GetAsync(url + "?url=http://localhost:5000/api/orderedJobs"); 
        var result = await response.Content.ReadAsStringAsync();

        Assert.That(result, Is.EqualTo(expected));
    }
}