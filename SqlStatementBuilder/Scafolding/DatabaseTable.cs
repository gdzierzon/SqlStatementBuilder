using System.Collections.Generic;

namespace SqlStatementBuilder.Scafolding
{
    public abstract class DatabaseTable
    {
        public string TableName { get; set; }
        public string Alias { get; private set; }

        public DatabaseTable As(string alias)
        {
            Alias = alias;
            return this;
        }

        public override string ToString()
        {
            if (Alias != null && Alias.Trim() != "")
            {
                return $"{TableName} AS {Alias}";
            }

            return TableName;
        }
    }
}