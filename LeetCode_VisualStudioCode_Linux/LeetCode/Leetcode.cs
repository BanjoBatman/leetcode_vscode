using System.Collections;
using System.Data;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using LeetCodeListNode;
using Microsoft.VisualBasic;

public class LeetCode
{
    /// <summary>
    /// this is just here to make sure the tests can access the code
    /// </summary>
    /// <returns>true</returns>
    public bool shouldReturnTrue()
    {
        return true;
    }

    // swap every two adjacent nodes in a linked list and return its head
    // Example 1:
    // Input: head = [1,2,3,4]
    // Output: [2,1,4,3]
    // Example 2:
    // Input: head = []
    // Output: []
    // Example 3:
    // Input: head = [1]
    // Output: [1]
    public ListNode? SwapPairs(ListNode? head)
    {
        if (head == null || head.next == null)
        {
            return head; // Nothing to swap or only one node
        }

        ListNode? current = head;
        ListNode? prev = null;
        ListNode? nextNode;

        head = head.next; // New head

        while (current != null && current.next != null)
        {
            nextNode = current.next.next; // save the node we're moving to the front
            current.next.next = current; // remove the 2nd node from the list .

            if (prev != null) // there is a previous node
            {
                prev.next = current.next; // point the previous node to the new head
            }
            prev = current;
            current.next = nextNode;
            current = nextNode;
        }

        return head;
    }

    /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
    ///Merge all the linked-lists into one sorted linked-list and return it.
    public ListNode? MergeKLists(ListNode?[] lists)
    {
        ListNode? result = null;
        ListNode? current = null;
        bool hasAvailableNodes = true;
        // find the smallest value in the list
        while (hasAvailableNodes)
        {
            hasAvailableNodes = false; // assume there are no more nodes
            int minIndex = int.MaxValue;
            foreach (ListNode? node in lists)
            {
                if (node != null)
                {
                    hasAvailableNodes = true; // there are still nodes available
                    if (node.val < minIndex)
                    {
                        minIndex = node.val;
                    }
                }
            }

            // find any of the listnodes whose value is equal to the minIndex
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode? node = lists[i];
                //Console.WriteLine(string.Format("Checking {0}", node?.val.ToString() ?? "null"));
                if (node != null && node.val == minIndex)
                {
                    // the node is not null, and the nodevalue matches the minimum index
                    if (result == null)
                    {
                        // this is the first node in the new list
                        result = new ListNode(node.val);
                        result.next = null;
                        current = result;
                    }
                    else
                    {
                        // this is not the first node in the new list
                        // current can't be null here
                        current!.next = new ListNode(node.val); // create a new node with the current value
                        current = current.next; // move the current pointer forward
                        current.next = null; // ensure the next pointer is null to end the list
                    }
                    if (lists[i] != null)
                    {
                        // move this linkedList forward to the next element
                        lists[i] = lists[i]!.next;
                    }
                }
            }
        }

        return result;
    }

    void debugListNode(ListNode? head, string name)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("******************* " + name + " *******************");
        ListNode? temp = head;
        Console.Write("\t\t");
        while (temp != null)
        {
            Console.Write(temp.val.ToString() + ",");
            temp = temp.next;
        }
        Console.WriteLine();
        Console.Write("********************");
        for (int i = 0; i < name.Length; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine("********************");
    }

    /// <summary>
    ///  generate a list of all combinations of n pairs of parenthesis
    ///  Example 1:
    ///     Input: n = 3
    ///     Output: ["((()))","(()())","(())()","()(())","()()()"]
    ///  Example 2:
    ///     Input: n = 1
    ///     Output: ["()"]
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>

    public IList<string> GenerateParenthesis(int n)
    {
        //StringBuilder parens = new StringBuilder();
        StringBuilder final = new StringBuilder();
        //List<string> pairs = new List<string>();

        List<string> result = new List<string>();
        BacktrackGenerateParenthesis("", n, n, result);
        return result;
    }

    void BacktrackGenerateParenthesis(
        string current,
        int numberOfOpen,
        int numberOfClose,
        List<string> result
    )
    {
        if (numberOfOpen == 0 && numberOfClose == 0)
        {
            result.Add(current);
            return;
        }
        if (numberOfOpen > 0)
        {
            BacktrackGenerateParenthesis(current + "(", numberOfOpen - 1, numberOfClose, result);
        }
        if (numberOfClose > numberOfOpen)
        {
            BacktrackGenerateParenthesis(current + ")", numberOfOpen, numberOfClose - 1, result);
        }
    }

    /// <summary>
    /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
    ///A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
    ///     Example 1:
    ///         Input: digits = "23"
    ///         Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
    ///     Example 2:
    ///         Input: digits = ""
    ///         Output: []
    ///     Example 3:
    ///         Input: digits = "2"
    ///         Output: ["a","b","c"]
    /// </summary>
    /// <param name="digits">list of telephone digits from[2-9]</param>
    /// <returns></returns>
    public IList<string> LetterCombinations(string digits)
    {
        return dfsLetterCombinations(digits, "");
    }

    //recursive search
    IList<string> dfsLetterCombinations(string digits, string currentResult)
    {
        List<string> result = new List<string>();
        if (digits.Length > 0)
        {
            // parse the digit and get back the result
            char digit = digits[0];
            digits = digits.Remove(0, 1);
            switch (digit)
            {
                case '2':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "a"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "b"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "c"));
                    break;
                case '3':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "d"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "e"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "f"));
                    break;
                case '4':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "g"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "h"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "i"));
                    break;
                case '5':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "j"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "k"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "l"));
                    break;
                case '6':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "m"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "n"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "o"));
                    break;
                case '7':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "p"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "q"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "r"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "s"));
                    break;
                case '8':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "t"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "u"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "v"));
                    break;
                case '9':
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "w"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "x"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "y"));
                    result.AddRange(dfsLetterCombinations(digits, currentResult + "z"));
                    break;
            }
        }
        else
        {
            if (currentResult.Length > 0)
                result.Add(currentResult);
        }

        return result;
    }

    /*
        Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

        0 <= a, b, c, d < n
        a, b, c, and d are distinct.
        nums[a] + nums[b] + nums[c] + nums[d] == target
        You may return the answer in any order.
    */

    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        // a list of the numbers in num that sum to target
        IList<IList<int>> result = new List<IList<int>>();
        HashSet<(int, int, int, int)> memo = new HashSet<(int, int, int, int)>();
        HashSet<int> usedIVals = new HashSet<int>();

        // pointers to keep track of where we are in the search
        int i = 0,
            j = 0,
            k = 0,
            l = 0;

        // sort the nums list
        nums = [.. nums.Order<int>()];

        for (i = 0; i <= nums.Length - 4; i++)
        {
            while (i <= nums.Length - 4 && usedIVals.Contains(nums[i]))
            {
                i++; //no sense repeating the same i value
            }
            if (nums[i] > target && target > -1)
            {
                i = nums.Length - 4; //no more solutions are possible.
            }
            usedIVals.Add(nums[i]);
            for (j = i + 1; j <= nums.Length - 3; j++)
            {
                for (k = j + 1; k <= nums.Length - 2; k++)
                {
                    for (l = k + 1; l <= nums.Length - 1; l++)
                    {
                        Console.WriteLine("{0}:{1}:{2}:{3}", i, j, k, l);
                        while (l < nums.Length - 1 && sum(nums, i, j, k, l) < target)
                        {
                            l++;
                        }

                        if (sum(nums, i, j, k, l) == (long)target)
                        {
                            if (memo.Contains((nums[i], nums[j], nums[k], nums[l])) != true)
                            {
                                Console.WriteLine("Solution at {0}:{1}:{2}:{3}", i, j, k, l);
                                Console.WriteLine(
                                    "Solution is {0}:{1}:{2}:{3}",
                                    nums[i],
                                    nums[j],
                                    nums[k],
                                    nums[l]
                                );
                                result.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                                memo.Add((nums[i], nums[j], nums[k], nums[l]));
                            }
                        }
                    }
                }
            }
        }

        return result;
    }

    long sum(int[] nums, int i, int j, int k, int l)
    {
        return (long)nums[i] + (long)nums[j] + (long)nums[k] + (long)nums[l];
    }

    // when you encounter a number, the string prior to the number is repeated that many times
    // so aa3bb2cc would be interpreted as aaaaaabbbbcc
    // given that, find the information at the index (1 based, not 0 based)
    public string DecodeAtIndex(string s, int k)
    {
        long currentLength = 0;
        //calculate the length of the final string as if we recreated it.
        foreach (char c in s)
        {
            if (Char.IsDigit(c))
            {
                currentLength *= c - '0'; //a cheap way to convert ascii to an int
            }
            else
            {
                //increment the count
                currentLength++;
            }
        }

        // now work backwards
        for (int i = s.Length - 1; i >= 0; i--)
        {
            // the index exceeds the current length of the string.
            // the modulus will map the index back into the lenght of the string.
            if (currentLength < k)
            {
                k %= (int)currentLength;
            }

            // if this criteria is met, then this is the matching char
            if ((k == 0 || currentLength == k) && !Char.IsDigit(s[i]))
            {
                return s[i].ToString();
            }

            // if we encounter a digit, divide the current length by that digit
            if (Char.IsDigit(s[i]))
            {
                currentLength /= (s[i] - '0');
            }
            else
            {
                //subtract 1
                currentLength--;
            }
        }
        // safety value.
        throw new ArgumentException("invalid input. ");
    }

    // return true if n is a power of 3
    public bool IsPowerOfThree(int n)
    {
        if (n == int.MinValue)
        {
            return false;
        }
        if (n == 1)
        {
            return true; //3^0
        }

        if (n < 3)
        {
            return false;
        }
        while (n % 3 == 0)
        {
            n /= 3;
        }
        return n == 1;
    }

    // return the length of the longest increasing subsequence
    public int LengthOfLIS(int[] nums)
    {
        int absoluteMax = 1;
        int[] dp = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1; // dp[i] will always start at 1
            int currentMaxSubsetFromI = dp[i];
            for (int j = i - 1; j >= 0; j--)
            { // for all elements below this one,
                // if nums[j] is lower than this value,
                if (nums[j] < nums[i])
                {
                    int newMax = dp[j] + 1;
                    if (dp[i] < (dp[j] + 1))
                    {
                        dp[i] = (dp[j] + 1);
                        if (dp[i] > absoluteMax)
                        {
                            absoluteMax = dp[i];
                        }
                    }
                }
            }
        }
        return absoluteMax;
    }

    /// <summary>
    /// return the acount of strings in words that contain pref
    /// </summary>
    /// <param name="words"></param>
    /// <param name="pref"></param>
    /// <returns></returns>
    public int PrefixCount(string[] words, string pref)
    {
        return words.Where(x => x.IndexOf(pref) == 0).Count();
    }

    /// <summary>
    /// checks a string containing only (){}[]
    /// </summary>
    /// <param name="s">a string containing the parenthesis</param>
    /// <returns>true if the parenthesis only contain valid closures</returns>
    public bool IsValid(string s)
    {
        if (s.Length < 2)
        {
            return false; // not possible
        }
        char[] open = new char[] { '(', '{', '[' };
        char[] close = new char[] { ')', '}', ']' };
        int closedIndex = -1;
        int openIndex = -1;
        while (s.Length > 0)
        {
            closedIndex = s.IndexOfAny(close); // the index of the first close char in the string
            if (closedIndex == 0 || closedIndex == -1)
            {
                return false;
            }
            char closedChar = s[closedIndex];
            openIndex = closedIndex - 1; // this has to be a matching open index to be valid
            char openChar = s[openIndex];
            for (int i = 0; i < open.Length; i++)
            {
                if (open[i] == openChar)
                {
                    if (close[i] == closedChar)
                    {
                        // remove the two indexes from the string
                        s = s.Remove(openIndex, 1);
                        s = s.Remove(openIndex, 1);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        return s.Length == 0;
    }
}
