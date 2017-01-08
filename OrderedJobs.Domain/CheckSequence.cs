using System.Collections.Generic;
using System.Linq;

public class CheckSequence {
    private IEnumerable<string> dependentJobs;
    public string GetResult(string testCase, string orderedTestCase) {
        FilterDependentJobs(testCase);
        foreach (var job in dependentJobs) {
            if (orderedTestCase.IndexOf(job[0]) < orderedTestCase.IndexOf(job[2])) {
                return "FAIL with " + orderedTestCase + ", expected " + job[2] + " before " + job[0];
            }
        }
        return "PASS";
    }

    public void FilterDependentJobs(string testCase) {
        string[] jobArr = testCase.Split('|');
        dependentJobs = jobArr.Where(job => job.Length == 3);
    }
}