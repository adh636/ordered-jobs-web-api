using System.Collections.Generic;

public class TestCaseResult {
    public List<TestCasePermutationResult> permutationResults = new List<TestCasePermutationResult>();
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCaseResult(TestCase testCase) {
        this.testCase = testCase.testCase;
        List<string> testCasePermutations = new AllPermutations().GetPermutations(this.testCase, '|');
        foreach (string testCasePermutation in testCasePermutations) {
            permutationResults.Add(new TestCasePermutationResult(testCasePermutation));
        }
        result = GetResult();
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