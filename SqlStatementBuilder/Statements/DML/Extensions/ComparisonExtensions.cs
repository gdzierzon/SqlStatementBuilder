using System;

namespace SqlStatementBuilder.Statements.DML.Extensions
{
    public static class ComparisonExtensions
    {
        public static string IsLike(this string item, string expectedValue) 
        {
            return $"{item} LIKE '{expectedValue}'";
        } 

        public static string IsEqualTo(this string item, string expectedValue) 
        {
            return $"{item} = '{expectedValue}'";
        } 
        public static string IsEqualTo<T>(this string item, T expectedValue) where T: struct
        {
            return $"{item} = {expectedValue}";
        } 
        
        public static string IsGreaterThan(this string item, string expectedValue) 
        {
            return $"{item} > '{expectedValue}'";
        } 
        public static string IsGreaterThan<T>(this string item, T expectedValue) where T: struct
        {
            return $"{item} > {expectedValue}";
        } 
        
        public static string IsGreaterThanOrEqualTo(this string item, string expectedValue) 
        {
            return $"{item} >= '{expectedValue}'";
        } 
        public static string IsGreaterThanOrEqualTo<T>(this string item, T expectedValue) where T: struct
        {
            return $"{item} >= {expectedValue}";
        } 
        
        public static string IsLessThan(this string item, string expectedValue) 
        {
            return $"{item} < '{expectedValue}'";
        } 
        public static string IsLessThan<T>(this string item, T expectedValue) where T: struct
        {
            return $"{item} < {expectedValue}";
        } 
        
        public static string IsLessThanOrEqualTo(this string item, string expectedValue) 
        {
            return $"{item} <= '{expectedValue}'";
        } 
        public static string IsLessThanOrEqualTo<T>(this string item, T expectedValue) where T: struct
        {
            return $"{item} <= {expectedValue}";
        } 
        

        public static string Between<T>(this string item, T left, T right)
        {
            return $"{item} BETWEEN {left} AND {right}";
        }
    }
}