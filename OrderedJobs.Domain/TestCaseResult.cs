using System.Collections.Generic;

public class TestCaseResult {
    public List<TestCasePermutationResult> permutationResults = new List<TestCasePermutationResult>();
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCaseResult(TestCase testCase, string url) {
        this.testCase = testCase.testCase;
        List<string> testCasePermutations = new AllPermutations().GetPermutations(this.testCase, '|');
        foreach (string testCasePermutation in testCasePermutations) {
            AddTestCasePermutationResult(testCasePermutation, url);
        }
        result = GetResult();
    }

    public void AddTestCasePermutationResult(string testCasePermutation, string url) {
        permutationResults.Add(new TestCasePermutationResult(testCasePermutation, url));
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