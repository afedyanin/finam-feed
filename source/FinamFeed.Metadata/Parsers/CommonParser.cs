namespace FinamFeed.Metadata.Parsers
{
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class CommonParser
    {
        private const string CONST_NamesPattern = @"\'(\\.|[^\'])*\'";

        public static string[] GetNames(string namesString)
        {
            return (from Match m in Regex.Matches(namesString, CONST_NamesPattern) select m.Groups[0].Value).ToArray();
        }

        public static string GetLineByKey(string key, string[] lines)
        {
            if (lines == null)
            {
                return string.Empty;
            }

            return lines.FirstOrDefault(x => x.Contains(key)) ?? string.Empty;
        }

        public static string GetArrayValues(string rawString)
        {
            return rawString.RemoveFirstAndLast('[', ']');
        }

        public static string RemoveQuotes(this string rawString)
        {
            return rawString.RemoveFirstAndLast('\'', '\'');
        }

        public static string RemoveFirstAndLast(this string source, char first, char last)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            var temp = source;
            var idx1 = source.IndexOf(first);
            var idx2 = source.LastIndexOf(last);

            if (idx2 > 0)
            {
                temp = temp.Remove(idx2);
            }

            if (idx1 >=0)
            {
                temp = temp.Substring(idx1 + 1);
            }

            return temp;
        }

        public static string GetJsonArrayString(this string source)
        {
            var res = string.Empty;

            if (string.IsNullOrEmpty(source))
            {
                return res;
            }

            var idx1 = source.IndexOf('[');

            if (idx1 == 0)
            {
                return res;
            }

            var idx2 = source.LastIndexOf(']');

            if (idx2 == 0)
            {
                return res;
            }

            if (idx2 < source.Length - 1)
            {
                res = source.Remove(idx2 + 1);
            }

            return res.Substring(idx1);
        }
    }
}
