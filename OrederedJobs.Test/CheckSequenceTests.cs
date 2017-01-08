using NUnit.Framework;

[TestFixture]
public class CheckSequenceTests {
    CheckSequence cs;
    
    [SetUp]
	public void InitializeOrderedJobsClass()
	{
	    cs = new CheckSequence();
	}

    [Test]
    public void NoJobs() {
        string testCase = "";
        string orderedTestCase = "";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("PASS"));
    }
        
    [Test]
    public void OneJob() {
        string testCase = "a-";
        string orderedTestCase = "a";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("PASS"));
    }
    
    [Test]
    public void MultipleJobsSameOrder() {
        string testCase = "a-|b-|c-";
        string orderedTestCase = "abc";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("PASS"));
    }

    [Test]
    public void MultipleJobsDifferentOrder() {
        string testCase = "a-|b-|c-";
        string orderedTestCase = "cba";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("PASS"));
    }
        
    [TestCase]
    public void MultipleJobsOneDependency() {
        string testCase = "a-|b-c|c-";
        string orderedTestCase = "acb";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("PASS"));
    }

    [TestCase]
    public void MultipleJobsOneDependencyWrongOrder() {
        string testCase = "a-|b-c|c-";
        string orderedTestCase = "abc";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("FAIL with abc, expected c before b"));
    }
            
    [TestCase]
    public void MultipleJobsMultipleDependency() {
        string testCase = "a-|b-c|c-f|d-a|e-b|f-";
        string orderedTestCase = "afcdbe";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("PASS"));
    }

    [TestCase]
    public void MultipleJobsMultipleDependencyWrongOrder() {
        string testCase = "a-|b-c|c-f|d-a|e-b|f-";
        string orderedTestCase = "dafcbe";
        Assert.That(cs.GetResult(testCase, orderedTestCase), Is.EqualTo("FAIL with dafcbe, expected a before d"));
    }
}