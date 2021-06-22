using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SqlStatementBuilder.Statements.DML
{
    public class Insert: DmlStatement
    {
        private readonly List<string> values;

        public Insert()
            : base("INSERT INTO")
        {
            values = new List<string>();
        }

        public Insert(string table)
            : base("INSERT INTO")
        {
            values = new List<string>();
            Table(table);
        }

        public Insert Table(string table)
        {
            TableName = table;
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
                this.values.Add(value.ToString());
            }
            return this;
        }

        public Insert Select(Select select)
        {
            return this;
        }

        public override string ToString()
        {
            StringBuilder query = new StringBuilder(Action);

            if (TableName != null && !TableName.Equals(string.Empty))
            {
                query.Append($" {TableName}");
            }

            if (TableColumns.Count > 0)
            {
                var columnNames = TableColumns.Select(c => c.ToString()).ToList();
                var columns = string.Join(", ", columnNames.ToArray());
                query.Append($" ({columns})");
            }

            if (values.Count > 0)
            {
                var values = string.Join(", ", this.values.ToArray());
                query.Append($" VALUES ({values})");
            }

            return query.ToString();
        }
    }
}