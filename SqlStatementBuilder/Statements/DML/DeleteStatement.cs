using System.Text;
using SqlStatementBuilder.Statements.DML.Conditions;

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

        #region Conditions

        public DeleteStatement Where(string condition)
        {
            AddCondition(Condition.Where(condition));
            return this;
        }

        public DeleteStatement WhereNot(string condition)
        {
            AddCondition(Condition.WhereNot(condition));
            return this;
        }

        public DeleteStatement And(string condition)
        {
            AddCondition(Condition.And(condition));
            return this;
        }

        public DeleteStatement AndNot(string condition)
        {
            AddCondition(Condition.AndNot(condition));
            return this;
        }

        #endregion

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