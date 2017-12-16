using System.Collections.Generic;
using System.Text;
using SqlStatementBuilder.Statements.DML.Conditions;
using SqlStatementBuilder.Statements.DML.Enumerations;

namespace SqlStatementBuilder.Statements.DML
{
    public class SelectStatement: DmlStatement
    {
        private int? _top { get; set; }

        internal SelectStatement()
            :base("SELECT")
        { }

        public SelectStatement Top(int rows)
        {
            _top = rows;
            return this;
        }

        #region Columns

        public SelectStatement Columns(params object[] columns)
        {
            InsertColumns(columns);
            return this;
        }

        #region Aggregates

        public SelectStatement Count(string column)
        {
            ColumnNames.Add($"COUNT({column})");
            return this;
        }

        public SelectStatement Sum(string column)
        {
            ColumnNames.Add($"SUM({column})");
            return this;
        }

        public SelectStatement Average(string column)
        {
            ColumnNames.Add($"AVG({column})");
            return this;
        }

        public SelectStatement Min(string column)
        {
            ColumnNames.Add($"MIN({column})");
            return this;
        }

        public SelectStatement Max(string column)
        {
            ColumnNames.Add($"MAX({column})");
            return this;
        }

        #endregion

        #endregion

        #region Tables

        public SelectStatement From(string table)
        {
            TableName = table;
            return this;
        }

        #endregion

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