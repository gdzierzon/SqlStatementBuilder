using System.Collections.Generic;
using SqlStatementBuilder.Statements.DML.Conditions;
using SqlStatementBuilder.Statements.DML.Enumerations;

namespace SqlStatementBuilder.Statements.DML
{

    public abstract class DmlStatement
    {
        protected string Action { get; set; }
        protected string TableName { get; set; }
        protected List<string> ColumnNames { get; set; }
        protected List<string> Conditions { get; set; }

        protected DmlStatement(string action)
        {
            Action = action;
            ColumnNames = new List<string>();
            Conditions = new List<string>();
        }

        protected void InsertColumns(params object[] columns)
        {
            foreach (var column in columns)
            {
                ColumnNames.Add(column.ToString());
            }
        }
        
        protected void AddCondition(string condition)
        {
            Conditions.Add(condition);
        }

    }
}
