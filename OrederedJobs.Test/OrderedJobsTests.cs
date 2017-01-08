using NUnit.Framework;
using Moq;

[TestFixture]
public class OrderedJobsTests {
    OrderedJobs oj;
    Mock<OrderedJobs> mock;
    
    [SetUp]
	public void InitializeOrderedJobsClass()
	{
	    oj = new OrderedJobs();
        mock = new Mock<OrderedJobs>();
        mock.Setup(oj => oj.order(It.IsAny<string>())).Returns("testMock");
	}
    
    [Test]
    public void MockOrderedJobs() {
        Assert.That(mock.Object.order("dsafsadfsa"), Is.EqualTo("testMock"));
    }

    [Test]
    public void NoJobs() {
        Assert.That(oj.order(""), Is.EqualTo(""));
    }
        
    [Test]
    public void OneJob() {
        Assert.That(oj.order("a-"), Is.EqualTo("a"));
    }
    
    [Test]
    public void MultipleJobs() {
        Assert.That(oj.order("a-|b-|c-"), Is.EqualTo("abc"));
    }
        
    [TestCase]
    public void MultipleJobsOneDependency() {
        Assert.That(oj.order("a-|b-c|c-"), Is.EqualTo("acb"));
    }
            
    [TestCase]
    public void MultipleJobsMultipleDependency() {
        Assert.That(oj.order("a-|b-c|c-f|d-a|e-b|f-"), Is.EqualTo("afcdbe"));
    }
                
    [TestCase]
    public void SelfDependency() {
        Assert.That(oj.order("a-|b-|c-c"), Is.EqualTo("jobs can't depend on themselves"));
    }
                
    [TestCase]
    public void CircularDependency() {
        Assert.That(oj.order("a-|b-c|c-f|d-a|e-|f-b"), Is.EqualTo("jobs can't have circular dependencies"));
    }
}