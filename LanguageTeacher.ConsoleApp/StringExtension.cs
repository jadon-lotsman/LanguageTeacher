using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanguageTeacher.ConsoleApp
{
    public static class StringExtension
    {
        public static string Capitalize(this string str)
        {
            char[] letters = str.ToLower().ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            return string.Join("", letters);
        }

        public static string RemoveMultispaces(this string str)
        {
            str = str.Trim();
            str = Regex.Replace(str, @"\s+", " ");

            return new string(str);
        }

        public static string[] SplitIgnored(this string str, char separator, char ignore)
        {
            var parts = new List<string>();
            var current = new StringBuilder();
            bool isQuotes = false;

            foreach (char ch in str.RemoveMultispaces())
            {
                if (ch == ignore)
                {
                    isQuotes = !isQuotes;
                    continue;
                }

                if (ch == separator && isQuotes == false)
                {
                    parts.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(ch);
                }
            }

            parts.Add(current.ToString());

            return parts.ToArray();
        }
    }
}
