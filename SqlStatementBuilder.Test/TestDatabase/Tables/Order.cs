using SqlStatementBuilder.Scafolding;

namespace SqlStatementBuilder.Test.TestDatabase.Tables
{
    public class Order : DatabaseTable<Order>
    {
        public DatabaseColumn OrderId => new DatabaseColumn() { ColumnName = "OrderId", Table = this };
        public DatabaseColumn CustomerId => new DatabaseColumn() { ColumnName = "CustomerId", Table = this };
        public DatabaseColumn OrderDate => new DatabaseColumn() { ColumnName = "OrderDate", Table = this };

        public Order()
        {
            TableName = "Order";
        }
        public Order(DatabaseSchema schema)
            : base(schema)
        {
            TableName = "Order";
        }
    }
}