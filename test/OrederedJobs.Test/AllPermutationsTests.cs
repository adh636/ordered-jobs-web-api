using System.Collections.Generic;
using NUnit.Framework;
using ordered_jobs_web_api;

[TestFixture]
public class AllPermutationsTests {
    AllPermutations allPermutations;
    List<string> permutations;

    [SetUp]
    public void BeforeEachTest() {
        allPermutations = new AllPermutations();
        permutations = new List<string>();
    }

    [Test]
    public void OneCase() {
        string testCase = "a-";
        List<string> expected = new List<string>();
        expected.Add("a-");
        permutations = allPermutations.GetPermutations(testCase, '|');
        Assert.That(permutations, Is.EqualTo(expected));
    }

    [Test]
    public void TwoCases() {
        string testCase = "a-|b-";
        List<string> expected = new List<string>();
        expected.Add("a-|b-");
        expected.Add("b-|a-");
        permutations = allPermutations.GetPermutations(testCase, '|');
        Assert.That(permutations, Is.EqualTo(expected));
    }

    [Test]
    public void ThreeCases() {
        string testCase = "a-|b-a|c-";
        List<string> expected = new List<string>();
        expected.Add("a-|b-a|c-");
        expected.Add("b-a|a-|c-");
        expected.Add("c-|a-|b-a");
        expected.Add("a-|c-|b-a");
        expected.Add("b-a|c-|a-");
        expected.Add("c-|b-a|a-");
        permutations = allPermutations.GetPermutations(testCase, '|');
        Assert.That(permutations, Is.EqualTo(expected));
    }
}