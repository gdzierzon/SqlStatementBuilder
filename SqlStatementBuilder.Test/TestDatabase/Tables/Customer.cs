using SqlStatementBuilder.Scafolding;

namespace SqlStatementBuilder.Test.TestDatabase.Tables
{
    public class Customer : DatabaseTable<Customer>
    {
        public DatabaseColumn CustomerId => new DatabaseColumn() { ColumnName = "CustomerId", Table = this };
        public DatabaseColumn FirstName => new DatabaseColumn() { ColumnName = "FirstName", Table = this };
        public DatabaseColumn LastName => new DatabaseColumn() { ColumnName = "LastName", Table = this };
        public DatabaseColumn Age => new DatabaseColumn() { ColumnName = "Age", Table = this };
        public DatabaseColumn Email => new DatabaseColumn() { ColumnName = "Email", Table = this };

        public Customer()
        {
            TableName = "Customer";
        }

        public Customer(DatabaseSchema schema)
            : base(schema)
        {
            TableName = "Customer";
        }
    }
}