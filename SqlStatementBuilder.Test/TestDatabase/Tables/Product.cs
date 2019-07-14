using SqlStatementBuilder.Scafolding;

namespace SqlStatementBuilder.Test.TestDatabase.Tables
{
    public class Product : DatabaseTable<Product>
    {
        public DatabaseColumn ProductId => new DatabaseColumn() { ColumnName = "ProductId", Table = this };
        public DatabaseColumn ProductName => new DatabaseColumn() { ColumnName = "ProductName", Table = this };
        public DatabaseColumn Price => new DatabaseColumn() { ColumnName = "Price", Table = this };

        public Product()
        {
            TableName = "Product";
        }
        public Product(DatabaseSchema schema)
            : base(schema)
        {
            TableName = "Product";
        }
    }
}