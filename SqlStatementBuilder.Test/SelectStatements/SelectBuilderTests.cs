using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Scafolding;
using SqlStatementBuilder.Statements.DML.Extensions;
using dbo = TestDatabase.Dbo;

namespace SqlStatementBuilder.Test.SelectStatements
{
    [TestClass]
    public class SelectBuilderTests: SqlBuilder
    {

        [TestMethod]
        public void Select_WhereBetween_WithTableModels()
        {
            //Arrange
            var expected = "SELECT * FROM Product WHERE Price BETWEEN 10 AND 20";
            var p = dbo.Product;

            //Act
            var actual = Select("*")
                .From(dbo.Product)
                .Where(p.Price.Between(10,20))
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Select_WithTableModels_AndAliases()
        {
            //Arrange
            var expected = "SELECT * FROM Product AS p WHERE p.Price BETWEEN 10 AND 20";
            var p = dbo.Product;

            //Act
            var actual = Select("*")
                .From(dbo.Product.As("p"))
                .Where(p.Price.Between(10,20))
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Select_JoinsWithAliases()
        {
            //Arrange
            var expected = "SELECT c.CustomerId, c.FirstName, o.OrderDate, od.Price, od.Quantity, p.ProductName FROM Customer AS c INNER JOIN Order AS o ON c.CustomerId = o.CustomerId INNER JOIN OrderDetail AS od ON o.OrderId = od.OrderId INNER JOIN Product AS p ON od.ProductId = p.ProductId";

            var c = dbo.Customer;
            var o = dbo.Order;
            var od = dbo.OrderDetail;
            var p = dbo.Product;

            //Act
            var actual = Select(c.CustomerId,
                    c.FirstName,
                    o.OrderDate,
                    od.Price,
                    od.Quantity,
                    p.ProductName
                    )
                .From(dbo.Customer.As("c"))
                .Join(dbo.Order.As("o")).On(c.CustomerId.IsEqualTo(o.CustomerId))
                .Join(dbo.OrderDetail.As("od")).On(o.OrderId.IsEqualTo(od.OrderId))
                .Join(dbo.Product.As("p")).On(od.ProductId.IsEqualTo(p.ProductId))
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Select_OrderBy()
        {
            //Arrange
            var expected = "SELECT * FROM Customer AS c ORDER BY c.Age DESC, c.LastName ASC, c.FirstName";

            var c = dbo.Customer;

            //Act
            var actual = Select("*")
                .From(dbo.Customer.As("c"))
                .OrderBy(c.Age.Desc(), c.LastName.Asc(), c.FirstName)
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }
        
    }
}

namespace TestDatabase
{
    public static class Dbo
    {
        public static CustomerTable Customer = new CustomerTable();
        public static OrderTable Order = new OrderTable();
        public static OrderDetailTable OrderDetail = new OrderDetailTable();
        public static ProductTable Product = new ProductTable();

        public class CustomerTable : DatabaseTable
        {
            public DatabaseColumn CustomerId => new DatabaseColumn(){ColumnName = "CustomerId", Table = this};
            public DatabaseColumn FirstName => new DatabaseColumn(){ColumnName = "FirstName", Table = this};
            public DatabaseColumn LastName => new DatabaseColumn(){ColumnName = "LastName", Table = this};
            public DatabaseColumn Age => new DatabaseColumn(){ColumnName = "Age", Table = this};
            public DatabaseColumn Email => new DatabaseColumn(){ColumnName = "Email", Table = this};

            public CustomerTable()
            {
                TableName = "Customer";
            }
        }

        public class OrderTable : DatabaseTable
        {
            public DatabaseColumn OrderId => new DatabaseColumn(){ColumnName = "OrderId", Table = this};
            public DatabaseColumn CustomerId => new DatabaseColumn(){ColumnName = "CustomerId", Table = this};
            public DatabaseColumn OrderDate => new DatabaseColumn(){ColumnName = "OrderDate", Table = this};

            public OrderTable()
            {
                TableName = "Order";
            }
        }

        public class OrderDetailTable : DatabaseTable
        {
            public DatabaseColumn OrderDetailId => new DatabaseColumn(){ColumnName = "OrderDetailId", Table = this};
            public DatabaseColumn OrderId => new DatabaseColumn(){ColumnName = "OrderId", Table = this};
            public DatabaseColumn ProductId => new DatabaseColumn(){ColumnName = "ProductId", Table = this};
            public DatabaseColumn Price => new DatabaseColumn(){ColumnName = "Price", Table = this};
            public DatabaseColumn Quantity => new DatabaseColumn(){ColumnName = "Quantity", Table = this};

            public OrderDetailTable()
            {
                TableName = "OrderDetail";
            }
        }

        public class ProductTable:DatabaseTable
        {
            public DatabaseColumn ProductId => new DatabaseColumn(){ColumnName = "ProductId", Table = this};
            public DatabaseColumn ProductName => new DatabaseColumn(){ColumnName = "ProductName", Table = this};
            public DatabaseColumn Price => new DatabaseColumn(){ColumnName = "Price", Table = this};

            public ProductTable()
            {
                TableName = "Product";
            }
        }
    }
}