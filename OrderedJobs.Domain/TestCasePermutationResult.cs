public class TestCasePermutationResult {
    public string testCase {get; set;}
    public string result {get; set;}

    public TestCasePermutationResult(string testCase) {
        this.testCase = testCase;
        result = GetResult();
    }

    public string GetResult() {
        string orderedJob = new OrderedJobs().order(testCase);
        return new CheckSequence().GetResult(testCase, orderedJob);
    }
}