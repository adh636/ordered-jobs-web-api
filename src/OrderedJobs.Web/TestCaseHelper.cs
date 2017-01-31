using System;
using System.Collections.Generic;

public class TestCaseHelper {
    IHttpClient iHttpClient;
    IDataAccess dataAccess;
    public TestCaseHelper(IDataAccess dataAccess, IHttpClient iHttpClient)
    {
        this.iHttpClient = iHttpClient;
        this.dataAccess = dataAccess;
    }

    public OrderedJobsResult CollectingTestsCasesAndCheckingAgainstUrlAsync(string url)
    {
        IEnumerable<TestCase> testCases = dataAccess.GetAllTestCases();
        return new OrderedJobsResult(testCases, url, iHttpClient);
    }

    internal void InsertTestCase(TestCase testCase)
    {
        dataAccess.InsertOneTestCase(testCase);
    }

    internal void DeleteAllTestCases()
    {
        dataAccess.DeleteAllTestCases();
    }
}