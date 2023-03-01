using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace pipeline.helpers
{
    public static class StringExtensions
    {
        public static string PascalCaseToWords(this string text)
        {
            var words = SplitOnCapitals(text);
            return string.Join(" ",words);
        }

        private static IEnumerable<string> SplitOnCapitals(string text)
        {
            var regex = new Regex(@"\p{Lu}\p{Ll}*");
            foreach (Match match in regex.Matches(text))
            {
                yield return match.Value;    
            }
        }
    }
}
