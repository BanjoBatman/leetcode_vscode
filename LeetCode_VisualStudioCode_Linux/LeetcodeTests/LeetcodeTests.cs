using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using LeetCodeListNode;
using Newtonsoft.Json.Bson;

namespace LeetcodeTests;

[TestClass]
public sealed class TestLeetcode
{
    [TestMethod]
    public void TestSwapPairs()
    {
        LeetCode leetCode = new LeetCode();
        ListNode? nodes = ListNodeFromArray(new int[] { 1, 2, 3, 4 });
        ListNode? expected = ListNodeFromArray(new int[] { 2, 1, 4, 3 });
        ListNode? actual = leetCode.SwapPairs(nodes);
        AssertNodesAreEquivlent(expected, actual);

        nodes = ListNodeFromArray(new int[] { 1 });
        expected = ListNodeFromArray(new int[] { 1 });
        actual = leetCode.SwapPairs(nodes);
        AssertNodesAreEquivlent(expected, actual);

        nodes = ListNodeFromArray(new int[] { });
        expected = ListNodeFromArray(new int[] { });
        actual = leetCode.SwapPairs(nodes);
        AssertNodesAreEquivlent(expected, actual);
    }

    [TestMethod]
    public void TestMergeKLists()
    {
        LeetCode leetCode = new LeetCode();
        ListNode?[] lists = new ListNode[3];
        lists[0] = ListNodeFromArray(new int[] { 1, 4, 5 });
        lists[1] = ListNodeFromArray(new int[] { 1, 3, 4 });
        lists[2] = ListNodeFromArray(new int[] { 2, 6 });
        ListNode? expected = ListNodeFromArray(new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
        ListNode? actual = leetCode.MergeKLists(lists);
        AssertNodesAreEquivlent(expected, actual);

        lists = new ListNode[1];
        lists[0] = ListNodeFromArray(new int[] { 1, 4, 5 });
        expected = ListNodeFromArray(new int[] { 1, 4, 5 });
        actual = leetCode.MergeKLists(lists);
        AssertNodesAreEquivlent(expected, actual);

        lists = new ListNode[0];
        expected = null;
        actual = leetCode.MergeKLists(lists);
        AssertNodesAreEquivlent(expected, actual);

        lists = new ListNode[1];
        lists[0] = null;
        expected = null;
        actual = leetCode.MergeKLists(lists);
        AssertNodesAreEquivlent(expected, actual);
    }

    // private ListNode? ListNodeFromArray(int[] values)
    // {
    //     if (values.Length < 1)
    //     {
    //         return null;
    //     }
    //     ListNode node = new ListNode();
    //     node.val = values[0];
    //     ListNode? next = node;
    //     for (int i = 1; i < values.Length; i++)
    //     {
    //         next.next = new ListNode();
    //         next.next.val = values[i];
    //         next = next.next;
    //     }
    //     next.next = null;
    //     return node;
    // }

    [TestMethod]
    public void TestAreParenthesisValid()
    {
        string s = "()";
        bool expected = true;
        bool actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "(){}[]";
        expected = true;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "(){}[}";
        expected = false;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "(){[}]";
        expected = false;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "({[]})";
        expected = true;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "(";
        expected = false;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "(]]]]]]";
        expected = false;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "]]]]][]";
        expected = false;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);

        s = "[[[[[";
        expected = false;
        actual = new LeetCode().IsValid(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMergeTwoSortedLists()
    {
        ListNode? list1 = ListNodeFromArray(new int[] { 1, 2, 4 });
        ListNode? list2 = ListNodeFromArray(new int[] { 1, 3, 4 });
        ListNode? expected = ListNodeFromArray(new int[] { 1, 1, 2, 3, 4, 4 });
        ListNode? actual = new ListNodes().MergeTwoLists(list1, list2);
        AssertNodesAreEquivlent(expected, actual);

        list1 = null;
        list2 = null;
        expected = null;
        actual = new ListNodes().MergeTwoLists(list1, list2);
        AssertNodesAreEquivlent(expected, actual);

        list1 = ListNodeFromArray(new int[] { });
        list2 = ListNodeFromArray(new int[] { 0 });
        expected = ListNodeFromArray(new int[] { 0 });
        actual = new ListNodes().MergeTwoLists(list1, list2);
        AssertNodesAreEquivlent(expected, actual);
    }

    [TestMethod]
    public void TestRemoveNthNodeFromLinkedList()
    {
        int[] values = [1, 2, 3, 4, 5];
        ListNode? nodes = ListNodeFromArray(values);
        //PrintListNodes(nodes);
        ListNode? expected = ListNodeFromArray(new int[] { 1, 2, 3, 5 });
        ListNode? actual = new ListNodes().RemoveNthFromEnd(nodes, 2);
        AssertNodesAreEquivlent(expected, actual);

        nodes = ListNodeFromArray([1, 2]);
        expected = ListNodeFromArray([1]);
        actual = new ListNodes().RemoveNthFromEnd(nodes, 1);
        AssertNodesAreEquivlent(expected, actual);

        nodes = ListNodeFromArray(new int[] { 1 });

        expected = null;

        actual = new ListNodes().RemoveNthFromEnd(nodes, 1);

        AssertNodesAreEquivlent(expected, actual);
    }

    void AssertNodesAreEquivlent(ListNode? expected, ListNode? actual)
    {
        ListNode? tempExpected = expected;
        ListNode? tempActual = actual;
        while (tempExpected != null && tempActual != null)
        {
            Assert.AreEqual(tempExpected.val, tempActual.val);
            tempExpected = tempExpected.next;
            tempActual = tempActual.next;
        }

        Assert.IsTrue(tempExpected == null);
        Assert.IsTrue(tempActual == null);
    }

    ListNode? ListNodeFromArray(int[] values)
    {
        if (values.Length < 1)
        {
            return null;
        }
        ListNode node = new ListNode();
        node.val = values[0];
        ListNode? next = node;
        for (int i = 1; i < values.Length; i++)
        {
            next.next = new ListNode();
            next.next.val = values[i];
            next = next.next;
        }
        next.next = null;
        return node;
    }

    void PrintListNodes(ListNode nodes)
    {
        ListNode? temp = nodes;
        while (temp != null)
        {
            Console.Write(temp.val + ":");
            temp = temp.next;
        }
        Console.WriteLine();
    }

    [TestMethod]
    public void PrefixCount()
    {
        LeetCode leetCode = new LeetCode();
        string[] input = new string[] { "pay", "attention", "practice", "attend" };
        string pref = "at";
        int expected = 2;
        int actual = leetCode.PrefixCount(input, pref);
        Assert.AreEqual(expected, actual);

        input = new string[] { "leetcode", "win", "loops", "success" };
        pref = "code";
        expected = 0;
        actual = leetCode.PrefixCount(input, pref);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestLengthOfLIS()
    {
        LeetCode leetCode = new LeetCode();
        int[] input = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
        int expected = 4;
        int actual = leetCode.LengthOfLIS(input);
        Assert.AreEqual(expected, actual);

        input = new int[] { 0, 1, 0, 3, 2, 3 };
        expected = 4;
        actual = leetCode.LengthOfLIS(input);
        Assert.AreEqual(expected, actual);

        int numberOfElements = 2500;
        input = Enumerable.Range(1, numberOfElements).ToArray();
        expected = numberOfElements;
        actual = leetCode.LengthOfLIS(input);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestPowerOfThree()
    {
        LeetCode leetCode = new LeetCode();
        int n = 27;
        bool expected = true;
        bool actual = leetCode.IsPowerOfThree(n);
        Assert.AreEqual(expected, actual);

        n = 0;
        expected = false;
        actual = leetCode.IsPowerOfThree(n);
        Assert.AreEqual(expected, actual);

        n = 2 ^ 31 - 1;
        expected = false;
        actual = leetCode.IsPowerOfThree(n);
        Assert.AreEqual(expected, actual);

        n = -(2 ^ 31);
        expected = false;
        actual = leetCode.IsPowerOfThree(n);
        Assert.AreEqual(expected, actual);

        n = 45;
        expected = false;
        actual = leetCode.IsPowerOfThree(n);
        Assert.AreEqual(expected, actual);

        n = 4;
        expected = false;
        actual = leetCode.IsPowerOfThree(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDecodeAtIndex()
    {
        LeetCode leetCode = new LeetCode();
        string s = "leet2code3";
        int k = 10;
        string expected = "o";
        string actual = leetCode.DecodeAtIndex(s, k);
        Assert.AreEqual(expected, actual);

        s = "ha22";
        k = 5;
        expected = "h";
        actual = leetCode.DecodeAtIndex(s, k);
        Assert.AreEqual(expected, actual);

        s = "a23";
        k = 6;
        expected = "a";
        actual = leetCode.DecodeAtIndex(s, k);
        Assert.AreEqual(expected, actual);

        s = "a2b3";
        k = 9;
        expected = "b";
        actual = leetCode.DecodeAtIndex(s, k);
        Assert.AreEqual(expected, actual);

        s = "a2b3c4d5e6f7g8h9";
        k = 9;
        expected = "b";
        actual = leetCode.DecodeAtIndex(s, k);
        Assert.AreEqual(expected, actual);

        s = "leet2";
        k = 5;
        expected = "l";
        actual = leetCode.DecodeAtIndex(s, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test4Sum()
    {
        LeetCode leetCode = new LeetCode();
        int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
        int target = 0;
        IList<IList<int>> expected = new List<IList<int>>();
        expected.Add(new List<int> { -2, -1, 1, 2 });
        expected.Add(new List<int> { -2, 0, 0, 2 });
        expected.Add(new List<int> { -1, 0, 0, 1 });

        IList<IList<int>> actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[] { 2, 2, 2, 2, 2 };
        target = 8;
        expected.Clear();
        expected.Add(new List<int>() { 2, 2, 2, 2 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[] { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2000 };
        target = 2002;
        expected.Clear();
        expected.Add(new List<int>() { 0, 0, 2, 2000 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[]
        {
            2,
            -2,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            2000,
            2004,
        };
        target = 2002;
        expected.Clear();
        expected.Add(new List<int>() { 0, 0, 2, 2000 });
        expected.Add(new List<int>() { -2, 0, 0, 2004 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[]
        {
            2,
            -2,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            2002,
            2000,
            2004,
        };
        target = 2002;
        expected.Clear();
        expected.Add(new List<int>() { 0, 0, 2, 2000 });
        expected.Add(new List<int>() { -2, 0, 0, 2004 });
        expected.Add(new List<int> { -2, 0, 2, 2002 });
        expected.Add(new List<int> { 0, 0, 0, 2002 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[] { -3, -1, 0, 2, 4, 5 };
        target = 2;
        expected.Clear();
        expected.Add(new List<int>() { -3, -1, 2, 4 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[] { 1, -2, -5, -4, -3, 3, 3, 5 };
        target = -11;
        expected.Clear();
        expected.Add(new List<int>() { -5, -4, -3, 1 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[] { 1, -2, -5, -4, -3, 3, 3, 5 };
        target = -11;
        expected.Clear();
        expected.Add(new List<int>() { -5, -4, -3, 1 });
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);

        nums = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
        target = -294967296;
        expected.Clear();
        //expected.Add(new List<int>());
        actual = leetCode.FourSum(nums, target);
        AreEquivalent(expected, actual);
    }

    void AreEquivalent(IList<IList<int>> expected, IList<IList<int>> actual)
    {
        if (expected.Count != actual.Count)
        {
            throw new Exception(
                String.Format(
                    "expected length:{0} and actual length:{1} do not match",
                    expected.Count,
                    actual.Count
                )
            );
        }
        HashSet<(int, int, int, int)> expectedValues = new HashSet<(int, int, int, int)>();
        foreach (IList<int> v in expected)
        {
            expectedValues.Add((v[0], v[1], v[2], v[3]));
        }
        HashSet<(int, int, int, int)> actualValues = new HashSet<(int, int, int, int)>();
        foreach (IList<int> v in actual)
        {
            actualValues.Add((v[0], v[1], v[2], v[3]));
        }

        while (
            expectedValues.Count > 0
            && actualValues.Count > 0
            && expectedValues.Contains(actualValues.First())
        )
        {
            expectedValues.Remove(actualValues.ElementAt(0));
            actualValues.Remove(actualValues.ElementAt(0));
        }

        if (actualValues.Count != 0 || expectedValues.Count != 0)
        {
            throw new Exception("At least one element did not match.");
        }
    }

    List<List<int>> Concrete(IList<IList<int>> values)
    {
        List<List<int>> result = new List<List<int>>();
        foreach (IList<int> value in values)
        {
            List<int> conversionValues = new List<int>(value.ToArray());
            result.Add(conversionValues);
        }

        return result;
    }

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
        List<string> expected = new List<string>()
        {
            "ad",
            "ae",
            "af",
            "bd",
            "be",
            "bf",
            "cd",
            "ce",
            "cf",
        };
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
