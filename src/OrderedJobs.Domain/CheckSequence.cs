using System;
using System.Collections.Generic;
using System.Linq;

public class CheckSequence {
    private IEnumerable<string> dependentJobs;
    private string result;
    private string _testCase;
    private string _orderedTestCase;

    public string GetResult(string testCase, string orderedTestCase) {
        _testCase = testCase;
        _orderedTestCase = orderedTestCase;
        result = "PASS";

        if (NoJobs()) return result;
        if (UnequalLength()) return result;
        if (WrongJob()) return result;
        if (MultipleOfSameJob()) return result;
        FilterDependentJobs(testCase);
        if (WrongOrder()) return result;
        
        return result;
    }

    private Boolean NoJobs() {
        return _testCase == "" && _orderedTestCase == "";
    }

    private Boolean UnequalLength() {
        if (_testCase.Split('|').Length != _orderedTestCase.Length) {
            result = "FAIL with " + _orderedTestCase + ", expected length of " + _testCase.Split('|').Length;
            return true;
        }
        return false;
    }
    
    public Boolean WrongJob() {
        foreach (var job in _orderedTestCase) {
            if (_testCase.IndexOf(job) == -1) {
                result = "FAIL with " + _orderedTestCase + ", expected not to see " + job;
                return true;
            }
        }
        return false;
    }

    public Boolean MultipleOfSameJob() {
        foreach (var job in _orderedTestCase) {
            if (_orderedTestCase.Count(x => x == job) > 1) {
                result = "FAIL with " + _orderedTestCase + ", expected not to see duplicate jobs";
                return true;
            }
        }
        return false;
    }

    public void FilterDependentJobs(string testCase) {
        string[] jobArr = testCase.Split('|');
        dependentJobs = jobArr.Where(job => job.Length == 3);
    }

    private Boolean WrongOrder() {
        foreach (var job in dependentJobs) {
            if (_orderedTestCase.IndexOf(job[0]) < _orderedTestCase.IndexOf(job[2])) {
                result = "FAIL with " + _orderedTestCase + ", expected " + job[2] + " before " + job[0];
                return true;
            }
        }
        return false;
    }

}