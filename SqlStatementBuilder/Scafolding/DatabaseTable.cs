using System.Collections.Generic;
using System.Text;

namespace SqlStatementBuilder.Scafolding
{
    public abstract class DatabaseTable
    {
        public DatabaseSchema Schema { get; set; }
        public string TableName { get; set; }
        public string Alias { get; protected set; }

        protected DatabaseTable()
        {
            
        }

        protected DatabaseTable(DatabaseSchema schema)
        {
            this.Schema = schema;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (Schema != null)
            {
                builder.Append($"{Schema}.");
            }

            builder.Append($"[{TableName}]");

            if (Alias != null && Alias.Trim() != "")
            {
                builder.Append($" AS [{Alias}]");
            }

            return builder.ToString();
        }
    }

    public abstract class DatabaseTable<T>
        : DatabaseTable 
        where T : DatabaseTable<T>
    {
        protected DatabaseTable()
        {
            
        }

        protected DatabaseTable(DatabaseSchema schema)
            :base(schema)
        {
            
        }

        public T As(string alias)
        {
            Alias = alias;
            return (T)this;
        }
    }
}