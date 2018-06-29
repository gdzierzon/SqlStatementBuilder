namespace SqlStatementBuilder.Scafolding
{
    public class DatabaseColumn
    {
        public string ColumnName { get; set; }
        public string Alias { get; private set; }
        public DatabaseTable Table { get; set; }

        public DatabaseColumn As(string alias)
        {
            Alias = alias;
            return this;
        }

        public override string ToString()
        {
            return AliasedColumn;
        }

        private string AliasedColumn
        {
            get
            {
                if (Table.Alias != null && Table.Alias.Trim() != "")
                {
                    return $"{Table.Alias}.{ColumnName}";
                }

                return ColumnName;
            }
        }
        
        public string Between<T>(T left, T right)
        {
            return $"{AliasedColumn} BETWEEN {left} AND {right}";
        }

        public string IsEqualTo<T>(T expectedValue) 
        {
            return $"{AliasedColumn} = {expectedValue}";
        }

        public string Asc()
        {
            return $"{AliasedColumn} ASC";
        }

        public string Desc()
        {
            return $"{AliasedColumn} DESC";
        }
    }
}