using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Scafolding
{
    public abstract class SqlBuilder
    {
        protected Select Select(params object[] columns)
        {
            return new Select(columns);
        }

        protected Insert Insert(object table)
        {
            return new Insert(table);
        }

        protected Delete Delete(string table)
        {
            return new Delete(table);
        }
    }
}