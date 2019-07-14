using SqlStatementBuilder.Scafolding;
using SqlStatementBuilder.Test.TestDatabase.Tables;

namespace SqlStatementBuilder.Test.TestDatabase
{
    public class Dbo : DatabaseSchema
    {
        public Customer Customer;
        public Order Order;
        public OrderDetail OrderDetail;
        public Product Product;

        public Dbo() : base("dbo")
        {
            Customer = new Customer(this);
            Order = new Order(this);
            OrderDetail = new OrderDetail(this);
            Product = new Product(this);
        }
    }
}