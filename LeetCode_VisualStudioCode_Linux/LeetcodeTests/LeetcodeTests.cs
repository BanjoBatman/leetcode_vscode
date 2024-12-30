namespace LeetcodeTests;

[TestClass]
public sealed class TestLeetcode
{
    [TestMethod]
    public void TestLeetcodeProjectAccessible()
    {
        LeetCode leetCode = new LeetCode();
        Assert.AreEqual(true, leetCode.shouldReturnTrue());

    }

    [TestMethod]
    public void TestLetterCombinations()
    {
        LeetCode leetCode = new LeetCode();
        string input = "23";
        List<string> expected = new List<string>() { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
        List<string> actual = leetCode.LetterCombinations(input).ToList();
        CollectionAssert.AreEqual(expected, actual);

        input = "";
        expected = new List<string>();
        actual = leetCode.LetterCombinations(input).ToList();
        CollectionAssert.AreEqual(expected, actual);

        input = "2";
        expected = new List<string>() { "a", "b", "c" };
        actual = leetCode.LetterCombinations(input).ToList();
        CollectionAssert.AreEqual(expected, actual);

    }

    [TestMethod]
    public void TestRegularExpressionMatching()
    {

        RegularExpressionMatching regularExpressionMatching = new RegularExpressionMatching();
        bool expected = false;
        bool actual = regularExpressionMatching.isMatch("aa", "a");
        Assert.AreEqual(expected, actual);


        expected = true;
        actual = regularExpressionMatching.isMatch("aa", "a*");
        Assert.AreEqual(expected, actual);

        expected = true;
        actual = regularExpressionMatching.isMatch("aa", ".*");
        Assert.AreEqual(expected, actual);


    }
}
