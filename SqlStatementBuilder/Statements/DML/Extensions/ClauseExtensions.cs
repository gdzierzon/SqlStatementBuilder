using System.Collections.Generic;
using System.Linq;

namespace SqlStatementBuilder.Statements.DML.Extensions
{
    public static class ClauseExtensions
    {
        private static IEnumerable<string> ClauseList => new List<string>();

        public static string[] And<T>(this T clause, T condition)
        {
            var list = ClauseList.ToList();
            list.Add(clause.ToString());
            list.Add( $"AND {condition}");
            return list.ToArray();
        }

        public static string[] And<T>(this IEnumerable<T> enumerable, T condition)
        {
            var list = enumerable.Select(e => e.ToString()).ToList();
            list.Add($"AND {condition}");
            return list.ToArray();
        }

        public static string[] AndNot(this string clause, string condition)
        {
            var list = ClauseList.ToList();
            list.Add(clause);
            list.Add( $"AND NOT {condition}");
            return list.ToArray();
        }

        public static string[] AndNot(this IEnumerable<string> enumerable, string condition)
        {
            var list = enumerable.ToList();
            list.Add( $"AND NOT {condition}");
            return list.ToArray();
        }

        public static string[] Or(this string clause, string condition)
        {
            var list = ClauseList.ToList();
            list.Add(clause);
            list.Add($"OR {condition}");
            return list.ToArray();
        }

        public static string[] Or(this IEnumerable<string> enumerable, string condition)
        {
            var list = enumerable.ToList();
            list.Add($"OR {condition}");
            return list.ToArray();
        }

        public static string[] OrNot(this string clause, string condition)
        {
            var list = ClauseList.ToList();
            list.Add(clause);
            list.Add($"OR NOT {condition}");
            return list.ToArray();
        }

        public static string[] OrNot(this IEnumerable<string> enumerable, string condition)
        {
            var list = enumerable.ToList();
            list.Add( $"OR NOT {condition}");
            return list.ToArray();
        }
    }
}