using System.Collections.Generic;

public class OrderedJobsResult {
    public List<TestCaseResult> testCaseResults = new List<TestCaseResult>();
    public string result {get; set;}

    public OrderedJobsResult(IEnumerable<TestCase> testCases, string url, IHttpClient iHttpClient) {
        AddTestCaseResults(testCases, url, iHttpClient);
        result = GetResult();
    }

    public void AddTestCaseResults(IEnumerable<TestCase> testCases, string url, IHttpClient iHttpClient) {
        foreach (TestCase testCase in testCases) {
            testCaseResults.Add(new TestCaseResult(testCase, url, iHttpClient));
        }
    }

    public string GetResult() {
        foreach (TestCaseResult testCaseResult in testCaseResults) {
            if (testCaseResult.result != "PASS") {
                return "FAIL";
            }
        }
        return "PASS";
    }
}