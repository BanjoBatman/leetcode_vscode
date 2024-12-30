using System.Net.NetworkInformation;

public class RegularExpressionMatching
{
    public bool isMatch(string s, string p)
    {
        return dfs(s, p, 0, 0);
    }

    // recursively search for matches
    bool dfs(string s, string p, int sIndex, int pIndex)
    {
        if (sIndex == s.Length - 1 && pIndex == p.Length - 1)
        {
            return true; // the patterns match
        }

        if (pIndex > p.Length - 1)
        {
            return false; //no match is possible on this path
        }

        if (sIndex <= s.Length - 1 && s[sIndex] == p[pIndex] || p[pIndex] == '.')
        {
            //check if next char is a star
            if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
            {
                // follow the path where we both repeat this char, and when we don't
                return dfs(s, p, sIndex, pIndex + 2) || dfs(s, p, sIndex + 1, pIndex);
            }
            else
            {
                // increment both sIndex and pIndex to the next char, and continue. 
                return dfs(s, p, sIndex + 1, pIndex + 1);
            }

        }

        return false; // no match found. 


    }
}