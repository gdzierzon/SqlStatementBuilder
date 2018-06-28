using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Builders
{
    public static class SqlBuilder
    {

        #region Update
        #endregion

        #region Delete

        public static DeleteStatement Delete()
        {
            var query = new DeleteStatement();
            return query;

        }

        public static DeleteStatement Delete(string tableName)
        {
            var query = Delete().Table(tableName);
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