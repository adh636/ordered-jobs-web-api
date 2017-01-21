using System.Threading.Tasks;
using System.Net.Http;
using Moq;
using NUnit.Framework;

[TestFixture]
public class TestCasePermutationResultTests {
    Mock<IHttpClient> mockHttpClient;
    TestCasePermutationResult tcpResult;
        
    [Test]
    [Category("mock")]
    public void PassingResult() {
        string testCase = "a-|b-|c-";
        string url = "fakeUrl";

        mockHttpClient = new Mock<IHttpClient>();
        mockHttpClient.Setup(mock => mock.GetAsync(It.IsAny<string>())).Returns(
            Task.FromResult(new HttpResponseMessage() {
                    Content= new StringContent("abc")
                    }));

        tcpResult = new TestCasePermutationResult(testCase, url, mockHttpClient.Object);
        
        Assert.That(tcpResult.result, Is.EqualTo("PASS"));
    }

    [Test]
    [Category("mock")]
    public void FailingResult() {
        string testCase = "a-|b-|c-";
        string url = "fakeUrl";
        System.Console.WriteLine("mock1");
        mockHttpClient = new Mock<IHttpClient>();
        mockHttpClient.Setup(mock => mock.GetAsync(It.IsAny<string>())).Returns(
            Task.FromResult(new HttpResponseMessage() {
                    Content= new StringContent("aba")
                    }));
        System.Console.WriteLine("mock");
        tcpResult = new TestCasePermutationResult(testCase, url, mockHttpClient.Object);
        
        Assert.That(tcpResult.result, Is.EqualTo("FAIL with aba, expected not to see duplicate jobs"));
    }
}