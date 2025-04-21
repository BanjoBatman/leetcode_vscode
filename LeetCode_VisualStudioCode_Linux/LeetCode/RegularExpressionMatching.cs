using System.Globalization;
using System.Net.NetworkInformation;

public class RegularExpressionMatching
{
    public bool isMatch(string s, string p)
    {
        if (p.Length == 0) {
            return s.Length == 0;
        }

        bool firstMatch = (s.Length > 0 && (s[0] == p[0] || p[0] == '.'));

        if (p.Length >= 2 && p[1] == '*') {
            return (isMatch(s, p.Substring(2)) || (firstMatch && isMatch(s.Substring(1), p)));
        } else {
            return firstMatch && isMatch(s.Substring(1), p.Substring(1));
        }
    }

    // recursively search for matche
       

}