using SqlStatementBuilder.Scafolding;

namespace SqlStatementBuilder.Test.TestDatabase.Tables
{
    public class OrderDetail : DatabaseTable<OrderDetail>
    {
        public DatabaseColumn OrderDetailId => new DatabaseColumn() { ColumnName = "OrderDetailId", Table = this };
        public DatabaseColumn OrderId => new DatabaseColumn() { ColumnName = "OrderId", Table = this };
        public DatabaseColumn ProductId => new DatabaseColumn() { ColumnName = "ProductId", Table = this };
        public DatabaseColumn Price => new DatabaseColumn() { ColumnName = "Price", Table = this };
        public DatabaseColumn Quantity => new DatabaseColumn() { ColumnName = "Quantity", Table = this };

        public OrderDetail()
        {
            TableName = "OrderDetail";
        }
        public OrderDetail(DatabaseSchema schema)
            : base(schema)
        {
            TableName = "OrderDetail";
        }
    }
}