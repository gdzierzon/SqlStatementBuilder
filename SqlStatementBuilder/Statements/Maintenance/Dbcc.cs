namespace SqlStatementBuilder.Statements.Maintenance
{
    public static class Dbcc
    {
        public static string Reseed(string table)
        {
            return $"DBCC CHECKIDENT('{table}', RESEED)";
        }
        public static string Reseed(string table, int newId)
        {
            return $"DBCC CHECKIDENT('{table}', RESEED, {newId})";
        }

    }
}