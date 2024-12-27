namespace LeetcodeTests;

[TestClass]
public sealed class TestLeetcode
{
    [TestMethod]
    public void TestLeetcodeProjectAccessible()
    {
        LeetCode leetCode = new LeetCode();
        Assert.AreEqual(true,leetCode.shouldReturnTrue());
    
    }
}
