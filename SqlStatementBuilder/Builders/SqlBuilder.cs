using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Builders
{
    public static class SqlBuilder
    {
        #region Insert

        public static InsertStatement Insert()
        {
            var query = new InsertStatement();
            return query;

        }

        public static InsertStatement Insert(string tableName)
        {
            var query = Insert().Table(tableName);
            return query;

        }

        #endregion

        #region Select

        public static SelectStatement Select()
        {
            var query = new SelectStatement();
            return query;
        }

        public static SelectStatement Select(params object[] columns)
        {
            var query = Select().Columns(columns);
            return query;
        }

        public static SelectStatement SelectTop(int rows, params object[] columns)
        {
            var query = Select(columns);
            query.Top(rows);
            return query;
        }

        #endregion


        #region Truncate

        public static string TruncateTable(string table)
        {
            return $"TRUNCATE TABLE {table}";
        }

        #endregion
    }
}