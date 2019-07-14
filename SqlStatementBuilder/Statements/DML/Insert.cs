using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SqlStatementBuilder.Statements.DML
{
    public class Insert: DmlStatement
    {
        private readonly List<string> values;
        private Select select { get; set; }

        public Insert()
            : base("INSERT INTO")
        {
            values = new List<string>();
        }

        public Insert(object table)
            : base("INSERT INTO")
        {
            values = new List<string>();
            Table(table);
        }

        public Insert Table(object table)
        {
            TableName = table.ToString();
            return this;
        }

        public Insert Columns(params object[] columns)
        {
            InsertColumns(columns);
            return this;
        }

        public Insert Values(params object[] insertValues)
        {
            foreach (var value in insertValues)
            {
                var type = value.GetType();
                if (type == typeof(string) || type == typeof(DateTime))
                {
                    this.values.Add($"'{value}'");
                }
                else
                {
                    this.values.Add(value.ToString());
                }
            }
            return this;
        }

        public Insert Select(Select select)
        {
            this.select = select;
            return this;
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder($"{Action} ");
            
            if (TableName != null && !TableName.Equals(string.Empty))
            {
                query.Append($"{TableName}");
            }

            if (TableColumns.Count > 0)
            {
                var columnNames = TableColumns.Select(c => c.ToString()).ToList();
                var columns = string.Join(", ", columnNames.ToArray());
                query.Append($" ({columns})");
            }

            if (values.Count > 0)
            {
                var valuesString = string.Join(", ", this.values.ToArray());
                query.Append($" VALUES ({valuesString})");
            }

            if (select != null)
            {
                query.Append($" {select}");
            }

            return query.ToString();
        }
    }
}