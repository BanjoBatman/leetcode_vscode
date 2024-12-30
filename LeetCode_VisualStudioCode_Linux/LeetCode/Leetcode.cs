using System.Collections;
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
            if (currentResult.Length > 0) result.Add(currentResult);
        }


        return result;

    }







}