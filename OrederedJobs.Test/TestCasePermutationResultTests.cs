using Moq;
using NUnit.Framework;

[TestFixture]
public class TestCasePermutationResultTests {
    Mock<ExternalOrderedJobs> mockExternalOrderedJobs;
    TestCasePermutationResult tcpResult;
    
    [SetUp]
	public void InitializeOrderedJobsClass()
	{
        mockExternalOrderedJobs = new Mock<ExternalOrderedJobs>();
	}
    
    // [Test]
    // public void MockOrderedJobs() {
    //     string testCase = "a-|b-|c-";
    //     string url = "fakeUrl";
    //     mockExternalOrderedJobs.Setup(mock => mock.GetResult(It.IsAny<string>(), It.IsAny<string>())).Returns("abc");
	//     tcpResult = new TestCasePermutationResult(testCase, url);
        
    //     Assert.That(tcpResult.result, Is.EqualTo("abc"));
    // }
}