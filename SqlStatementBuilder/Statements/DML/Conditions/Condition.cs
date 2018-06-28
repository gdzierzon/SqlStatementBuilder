using System;
using System.Linq;

namespace SqlStatementBuilder.Statements.DML.Conditions
{
    public static class Condition
    {
        public static string Where(string condition)
        {
            return $"WHERE {condition}";
        }
        public static string WhereNot(string condition)
        {
            return $"WHERE NOT {condition}";
        }

        public static string And(string condition)
        {
            return $"AND {condition}";
        }

        public static string AndNot(string condition)
        {
            return $"AND NOT {condition}";
        }

        public static string Or(string condition)
        {
            return $"OR {condition}";
        }

        public static string OrNot(string condition)
        {
            return $"OR NOT {condition}";
        }

        public static string Combine(params string[] conditions)
        {
            var combinedConditions = string.Join(" ", conditions);
            return $"({combinedConditions})";
        }

        public static string Combine(params int[] conditions)
        {
            var stringConditions = conditions.Select(c => c.ToString()).ToArray();
            return Combine(stringConditions);
        }

        public static string Combine(params double[] conditions)
        {
            var stringConditions = conditions.Select(c => c.ToString()).ToArray();
            return Combine(stringConditions);
        }

        public static string Combine(params decimal[] conditions)
        {
            var stringConditions = conditions.Select(c => c.ToString()).ToArray();
            return Combine(stringConditions);
        }

        public static string Combine(params DateTime[] conditions)
        {
            var stringConditions = conditions.Select(c => $"'{c:s}'").ToArray();
            return Combine(stringConditions);
        }
    }
}