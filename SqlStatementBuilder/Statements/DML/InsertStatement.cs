using System.Text;
using System.Collections.Generic;

namespace SqlStatementBuilder.Statements.DML
{
    public class InsertStatement: DmlStatement
    {
        private List<string> _values { get; set; }

        internal InsertStatement()
            : base("INSERT INTO")
        {
            _values = new List<string>();
        }

        public InsertStatement Table(string table)
        {
            TableName = table;
            return this;
        }

        public InsertStatement Columns(params object[] columns)
        {
            InsertColumns(columns);
            return this;
        }

        public InsertStatement Values(params object[] values)
        {
            foreach (var value in values)
            {
                _values.Add(value.ToString());
            }
            return this;
        }

        public InsertStatement Select(SelectStatement select)
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

            if(ColumnNames.Count > 0)
            {
                var columns = string.Join(", ", ColumnNames.ToArray());
                query.Append($" ({columns})");
            }

            if (_values.Count > 0)
            {
                var values = string.Join(", ", _values.ToArray());
                query.Append($" VALUES ({values})");
            }

            return query.ToString();
        }
    }
}