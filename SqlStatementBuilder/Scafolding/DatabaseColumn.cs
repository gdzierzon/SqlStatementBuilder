namespace SqlStatementBuilder.Scafolding
{
    public class DatabaseColumn
    {
        public string ColumnName { get; set; }
        public string Alias { get; private set; }
        public DatabaseTable Table { get; set; }

        public DatabaseColumn As(string alias)
        {
            Alias = alias.Trim();
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
                if (!string.IsNullOrEmpty(Table.Alias))
                {
                    return $"[{Table.Alias}].[{ColumnName}]";
                }

                return $"[{ColumnName}]";
            }
        }
        
        public string Between<T>(T min, T max)
        {
            return $"{AliasedColumn} BETWEEN {min} AND {max}";
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

        #region aggregates

        public string Aggregate(string function)
        {
            return $"{function.ToUpper()}({AliasedColumn})";
        }

        public string Count()
        {
            return Aggregate("COUNT");
        }

        public string Avg()
        {
            return Aggregate("AVG");
        }

        public string Min()
        {
            return Aggregate("MIN");
        }

        public string Max()
        {
            return Aggregate("MAX");
        }

        public string Sum()
        {
            return Aggregate("SUM");
        }

        #endregion
    }
}