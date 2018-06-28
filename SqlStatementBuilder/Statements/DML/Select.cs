using System.Collections.Generic;
using System.Text;
using SqlStatementBuilder.Statements.DML.Conditions;
using SqlStatementBuilder.Statements.DML.Enumerations;

namespace SqlStatementBuilder.Statements.DML
{
    public class Select: DmlStatement
    {
        private int? top;
        private readonly List<string> joinTables = new List<string>();
        private readonly List<string> joinConditions = new List<string>();

        public Select()
            :base("SELECT")
        { }

        public Select(params object[] columns)
            :this()
        {
            Columns(columns);
        }

        public Select Top(int rows)
        {
            top = rows;
            return this;
        }

        #region Columns

        public Select Columns(params object[] columns)
        {
            InsertColumns(columns);
            return this;
        }

        #region Aggregates

        public Select Count(string column)
        {
            ColumnNames.Add($"COUNT({column})");
            return this;
        }

        public Select Sum(string column)
        {
            ColumnNames.Add($"SUM({column})");
            return this;
        }

        public Select Average(string column)
        {
            ColumnNames.Add($"AVG({column})");
            return this;
        }

        public Select Min(string column)
        {
            ColumnNames.Add($"MIN({column})");
            return this;
        }

        public Select Max(string column)
        {
            ColumnNames.Add($"MAX({column})");
            return this;
        }

        #endregion

        #endregion

        #region Tables

        public Select From(string table)
        {
            TableName = table;
            return this;
        }

        #endregion

        #region Joins

        public Select Join(string table)
        {
            joinTables.Add($"INNER JOIN {table}");
            return this;
        }

        public Select LeftJoin(string table)
        {
            joinTables.Add($"LEFT OUTER JOIN {table}");
            return this;
        }

        public Select RightJoin(string table)
        {
            joinTables.Add($"RIGHT OUTER JOIN {table}");
            return this;
        }

        public Select On(string condition)
        {
            joinConditions.Add(condition);
            return this;
        }

        #endregion

        public override string ToString()
        {
            //select
            StringBuilder query = new StringBuilder("SELECT");

            if(top.HasValue)
            {
                query.Append($" TOP {top}");
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
            for (int i = 0; i < joinTables.Count; i++)
            {
                query.Append($" {joinTables[i]}");
                query.Append($" ON {joinConditions[i]}");
            }

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