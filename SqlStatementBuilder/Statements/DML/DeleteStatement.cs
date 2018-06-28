using System.Text;

namespace SqlStatementBuilder.Statements.DML
{
    public class DeleteStatement: DmlStatement
    {
        internal DeleteStatement()
            :base("DELETE FROM")
        {
            
        }

        public DeleteStatement Table(string table)
        {
            TableName = table;
            return this;
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder(Action);

            //table
            if (TableName != null && !TableName.Equals(string.Empty))
            {
                query.Append($" {TableName}");
            }

            //where
            if (Conditions.Count > 0)
            {
                var conditions = string.Join(" ", Conditions.ToArray());
                query.Append($" {conditions}");
            }

            return query.ToString();
        }

    }
}