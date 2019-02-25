using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DigitalParadoxCLI
{
    public static class CompareExtensions
    {
        public static bool Like<T>(this T toSearch, string toFind) where T : IComparable
        {
            return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch?.ToString());
        }

        public static bool In<T>(this IEnumerable<T> value, params T[] args)
        {
            return args.All(q => value.Contains(q));
        }

        public static bool In<T>(this T value, params T[] args)
        {
            return args.Contains(value);
        }
        
    }
}
