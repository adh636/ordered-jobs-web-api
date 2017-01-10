using System.Collections.Generic;

public class OrderedJobsResult {
    public List<TestCaseResult> testCaseResults = new List<TestCaseResult>();
    public string result {get; set;}

    public OrderedJobsResult(List<TestCase> testCases, string url) {
        foreach (TestCase testCase in testCases) {
            testCaseResults.Add(new TestCaseResult(testCase, url));
        }
        result = GetResult();
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