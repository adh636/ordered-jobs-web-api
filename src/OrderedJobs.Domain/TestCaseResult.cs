using System.Collections.Generic;

public class TestCaseResult {
    public List<TestCasePermutationResult> permutationResults = new List<TestCasePermutationResult>();
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCaseResult(TestCase testCase, string url, IHttpClient iHttpClient) {
        this.testCase = testCase.testCase;
        AddPermutationResults(url, iHttpClient);
        result = GetResult();
    }

    public void AddPermutationResults(string url, IHttpClient iHttpClient) {
        List<string> testCasePermutations = new AllPermutations().GetPermutations(testCase, '|');
        foreach (string testCasePermutation in testCasePermutations) {
            permutationResults.Add(new TestCasePermutationResult(testCasePermutation, url, iHttpClient));
        }
    }

    public string GetResult() {
        foreach (TestCasePermutationResult permutationResult in permutationResults) {
            if (permutationResult.result != "PASS") {
                return "FAIL";
            }
        }
        return "PASS";
    }
}