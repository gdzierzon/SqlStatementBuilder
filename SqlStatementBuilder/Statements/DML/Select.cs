using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlStatementBuilder.Statements.DML
{
    public class Select: DmlStatement
    {
        private int? top;
        private readonly List<string> joinTables = new List<string>();
        private readonly List<string> joinConditions = new List<string>();
        private readonly List<object> orderByColumns = new List<object>();

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

        public Select Count(object column)
        {
            TableColumns.Add($"COUNT({column})");
            return this;
        }

        public Select Sum(object column)
        {
            TableColumns.Add($"SUM({column})");
            return this;
        }

        public Select Average(object column)
        {
            TableColumns.Add($"AVG({column})");
            return this;
        }

        public Select Min(object column)
        {
            TableColumns.Add($"MIN({column})");
            return this;
        }

        public Select Max(object column)
        {
            TableColumns.Add($"MAX({column})");
            return this;
        }

        #endregion

        #endregion

        #region Tables

        public Select From(object table)
        {
            TableName = table.ToString();
            return this;
        }

        #endregion

        #region Joins

        public Select Join(object table)
        {
            joinTables.Add($"INNER JOIN {table}");
            return this;
        }

        public Select LeftJoin(object table)
        {
            joinTables.Add($"LEFT OUTER JOIN {table}");
            return this;
        }

        public Select RightJoin(object table)
        {
            joinTables.Add($"RIGHT OUTER JOIN {table}");
            return this;
        }

        public Select On(string condition)
        {
            joinConditions.Add(condition);
            return this;
        }

        public Select On(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            joinConditions.Add(condition);
            return this;
        }

        #endregion

        #region Order
        
        public Select OrderBy(params object[] columns)
        {
            foreach (var column in columns)
            {
                orderByColumns.Add(column);
            }
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

            if (TableColumns.Count > 0)
            {
                var columnNames = TableColumns.Select(c => c.ToString()).ToList();
                var columns = string.Join(", ", columnNames.ToArray());
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
            if (orderByColumns.Count > 0)
            {
                var columns = orderByColumns.Select(c => c.ToString()).ToList();
                var orderBy = string.Join(", ", columns);
                query.Append($" ORDER BY {orderBy}");
            }

            return query.ToString();
        }
    }
}