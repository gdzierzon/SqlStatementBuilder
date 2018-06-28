using System.Collections.Generic;
using System.Linq;

namespace SqlStatementBuilder.Statements.DML.Extensions
{
    public static class ClauseExtensions
    {
        private static IEnumerable<string> ClauseList => new List<string>();

        public static string[] And(this string clause, string condition)
        {
            var list = ClauseList.ToList();
            list.Add( $"{clause} AND {condition}");
            return list.ToArray();
        }

        public static string[] And(this IEnumerable<string> enumerable, string condition)
        {
            var list = enumerable.ToList();
            list.Add($"AND {condition}");
            return list.ToArray();
        }

        public static string[] AndNot(this string clause, string condition)
        {
            var list = ClauseList.ToList();
            list.Add( $"{clause} AND NOT {condition}");
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
            list.Add( $"{clause} OR {condition}");
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
            list.Add( $"{clause} OR NOT {condition}");
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