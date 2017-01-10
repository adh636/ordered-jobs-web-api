using System.Net.Http;

public class TestCasePermutationResult {
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCasePermutationResult(string testCase, string url) {
        this.testCase = testCase;
        GetResult(url);
    }

    public async void GetResult(string url) {
        TestCaseHttpClient testCaseHttpClient = new TestCaseHttpClient();
        HttpResponseMessage response = await testCaseHttpClient.GetAsync(url + "/" + testCase);
        string orderedJob = await response.Content.ReadAsStringAsync();
        result = new CheckSequence().GetResult(testCase, orderedJob);
    }
}