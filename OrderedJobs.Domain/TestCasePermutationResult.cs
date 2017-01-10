using System.Net.Http;
using System.Threading.Tasks;

public class TestCasePermutationResult {
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCasePermutationResult(string testCase, string url) {
        this.testCase = testCase;
        GetResult(url);
    }

    public void GetResult(string url) {
        string orderedJob = GetExternalJobOrder(url).Result;
        result = new CheckSequence().GetResult(testCase, orderedJob);
    }

    public async Task<string> GetExternalJobOrder(string url) {
        TestCaseHttpClient testCaseHttpClient = new TestCaseHttpClient();
        HttpResponseMessage response = await testCaseHttpClient.GetAsync(url + "/" + testCase);
        return await response.Content.ReadAsStringAsync();
    }
}