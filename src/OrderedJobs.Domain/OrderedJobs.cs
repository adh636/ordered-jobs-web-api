using System;
using System.Collections.Generic;
using System.Linq;

public class OrderedJobs {
    private string orderedJobs = "";
    private IEnumerable<string> jobArr;
    private IEnumerable<string> independentJobs;
    private IEnumerable<string> dependentJobs;

    public string order(string jobs) {
        if (jobs == "") return "";
        splitAndFilterJobs(jobs);
        orderJobs();
        setErrorMessageIfUnorderedJobs();
        return orderedJobs;
    }

    private void setErrorMessageIfUnorderedJobs() {
        if (unorderedJobs()) {
            checkForSelfDependency();
            checkForCircularDependency();
        }
    }

    private void checkForCircularDependency() {
        if (orderedJobs != "jobs can't depend on themselves") {
            orderedJobs = "jobs can't have circular dependencies"; 
        }
    }

    private void checkForSelfDependency() {
        foreach (string job in dependentJobs) {
            if (jobDependsOnItself(job)) {
                orderedJobs = "jobs can't depend on themselves";
            }
        }
    }

    private Boolean jobDependsOnItself(string job) {
        return job[0] == job[2];
    }

    private Boolean unorderedJobs() {
        return orderedJobs.Length != jobArr.Count();
    }

    private void orderJobs() {
        orderIndependentJobs();
        orderDependentJobs();
    }

    private void orderDependentJobs() {
        Boolean jobAdded = true;
        while (jobAdded) {
            int orderedJobsLength = orderedJobs.Length;
            orderJobsIfDependencyOrdered();
            if (noNewJobsOrdered(orderedJobsLength)) jobAdded = false;
        }
    }

    private Boolean noNewJobsOrdered(int orderedJobsLength) {
        return orderedJobs.Length == orderedJobsLength;
    }

    private void orderJobsIfDependencyOrdered() {
        foreach (string job in dependentJobs) {
            if (jobNotOrderedAndDependencyOrdered(job)) {
                orderedJobs += job[0];
            }
        }
    }

    private Boolean jobNotOrderedAndDependencyOrdered(string job) {
        return orderedJobs.IndexOf(job[0]) == -1 && orderedJobs.IndexOf(job[2]) != -1;
    }

    private void orderIndependentJobs() {
        foreach (string job in independentJobs) {
            orderedJobs += job[0];
        }
    }

    private void splitAndFilterJobs(string jobs) {
        jobArr = jobs.Split('|');
        filterIndependentJobs();
        filterDependentJobs();
    }

    private void filterDependentJobs() {
        dependentJobs = jobArr.Where(job => job.Length == 3);
    }

    private void filterIndependentJobs() {
        independentJobs = jobArr.Where(job => job.Length < 3);
    }
}