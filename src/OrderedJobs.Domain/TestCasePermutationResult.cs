public class TestCasePermutationResult {
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCasePermutationResult(string testCase, string url, IHttpClient iHttpClient) {
        this.testCase = testCase;
        result = GetResult(url, iHttpClient);
    }

    public string GetResult(string url, IHttpClient iHttpClient) {
        string orderedJob = new ExternalOrderedJobs(iHttpClient).GetResult(testCase, url);
        System.Console.WriteLine(orderedJob);
        return new CheckSequence().GetResult(testCase, orderedJob);
    }
}