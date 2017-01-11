using System.Net.Http;
using System.Threading.Tasks;

public class TestCasePermutationResult {
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCasePermutationResult(string testCase, string url) {
        this.testCase = testCase;
        result = GetResult(url);
    }

    public string GetResult(string url) {
        string orderedJob = new ExternalOrderedJobs().GetResult(testCase, url);
        return new CheckSequence().GetResult(testCase, orderedJob);
    }
}