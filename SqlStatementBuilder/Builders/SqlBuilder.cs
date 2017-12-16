using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Builders
{
    public static class SqlBuilder
    {

        public static InsertStatement Insert => new InsertStatement();
        public static SelectStatement Select => new SelectStatement();

        public static string TruncateTable(string table)
        {
            return $"TRUNCATE TABLE {table}";
        }
    }
}