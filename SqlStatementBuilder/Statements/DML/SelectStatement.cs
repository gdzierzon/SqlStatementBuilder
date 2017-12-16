using System.Collections.Generic;
using System.Text;
using SqlStatementBuilder.Statements.DML.Conditions;
using SqlStatementBuilder.Statements.DML.Enumerations;

namespace SqlStatementBuilder.Statements.DML
{
    public class SelectStatement: DmlStatement
    {
        private int? _top { get; set; }

        internal SelectStatement() { }

        public SelectStatement Top(int rows)
        {
            _top = rows;
            return this;
        }

        public SelectStatement Count(string column)
        {
            ColumnNames.Add($"COUNT({column})");
            return this;
        }

        public SelectStatement Columns(params object[] columns)
        {
            InsertColumns(columns);
            return this;
        }

        public SelectStatement From(string table)
        {
            TableName = table;
            return this;
        }

        #region Conditions

        public SelectStatement Where(string condition)
        {
            AddCondition(Condition.Where(condition));
            return this;
        }

        public SelectStatement WhereNot(string condition)
        {
            AddCondition(Condition.WhereNot(condition));
            return this;
        }

        public SelectStatement And(string condition)
        {
            AddCondition(Condition.And(condition));
            return this;
        }

        public SelectStatement AndNot(string condition)
        {
            AddCondition(Condition.AndNot(condition));
            return this;
        }

        #endregion

        public override string ToString()
        {
            //select
            StringBuilder query = new StringBuilder("SELECT");

            if(_top.HasValue)
            {
                query.Append($" TOP {_top}");
            }

            if (ColumnNames.Count > 0)
            {
                var columns = string.Join(", ", ColumnNames.ToArray());
                query.Append($" {columns}");
            }

            //from
            if(TableName != null && !TableName.Equals(string.Empty))
            {
                query.Append($" FROM {TableName}");
            }
            
            //join

            //where
            if (Conditions.Count > 0)
            {
                var conditions = string.Join(" ", Conditions.ToArray());
                query.Append($" {conditions}");
            }

            //group by

            //having

            //order by

            return query.ToString();
        }
    }
}