using System.Runtime.CompilerServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Scafolding;
using SqlStatementBuilder.Statements.DML.Extensions;
using SqlStatementBuilder.Test.TestDatabase;
using SqlStatementBuilder.Test.TestDatabase.Tables;

namespace SqlStatementBuilder.Test.SelectStatements
{
    [TestClass]
    public class Select_WithSchemaAndBuilder_Tests : SqlBuilder
    {
        private Dbo dbo;

        [TestInitialize]
        public void Initialize()
        {
            dbo = new Dbo();
        }

        [TestMethod]
        public void Select_WhereBetween_WithTableModels()
        {
            //Arrange
            var expected = "SELECT * FROM [dbo].[Product] AS [p] WHERE [p].[Price] BETWEEN 10 AND 20";
            var p = dbo.Product.As("p");

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
            var expected = "SELECT * FROM [dbo].[Product] AS [p] WHERE [p].[Price] BETWEEN 10 AND 20";
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
            var expected = "SELECT [c].[CustomerId], [c].[FirstName], [o].[OrderDate], [od].[Price], [od].[Quantity], [p].[ProductName] FROM [dbo].[Customer] AS [c] INNER JOIN [dbo].[Order] AS [o] ON [c].[CustomerId] = [o].[CustomerId] INNER JOIN [dbo].[OrderDetail] AS [od] ON [o].[OrderId] = [od].[OrderId] INNER JOIN [dbo].[Product] AS [p] ON [od].[ProductId] = [p].[ProductId]";

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
            var expected = "SELECT * FROM [dbo].[Customer] AS [c] ORDER BY [c].[Age] DESC, [c].[LastName] ASC, [c].[FirstName]";

            var c = dbo.Customer;

            //Act
            var actual = Select("*")
                .From(dbo.Customer.As("c"))
                .OrderBy(c.Age.Desc(), c.LastName.Asc(), c.FirstName)
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Select_GroupBy()
        {
            //arrange
            var expected = "SELECT Count(*), [c].[Age] FROM [dbo].[Customer] AS [c] GROUP BY [c].[Age]";

            var c = dbo.Customer;

            //act
            var actual = Select("Count(*)"
                    , c.Age)
                .From(dbo.Customer.As("c"))
                .GroupBy(c.Age)
                .ToString();

            //assert
            actual.Should().BeEquivalentTo(expected, "group by columns should be appended");
        }

        [TestMethod]
        public void Select_GroupBy_WithHavingCount()
        {
            //arrange
            var expected = "SELECT Count(*), [c].[Age] FROM [dbo].[Customer] AS [c] GROUP BY [c].[Age] HAVING Count(*) > 2";

            var c = dbo.Customer;

            //act
            var actual = Select("Count(*)"
                    , c.Age)
                .From(dbo.Customer.As("c"))
                .GroupBy(c.Age)
                .Having("Count(*)".IsGreaterThan(2))
                .ToString();

            //assert
            actual.Should().BeEquivalentTo(expected, "group by columns should be appended");
        }

        [TestMethod]
        public void Select_GroupBy_WithHavingAvg()
        {
            //arrange
            var expected = "SELECT AVG([c].[Age]), [c].[FirstName] FROM [dbo].[Customer] AS [c] GROUP BY [c].[FirstName] HAVING AVG([c].[Age]) > 20";

            var c = dbo.Customer.As("c");

            //act
            var actual = Select(c.Age.Avg()
                    , c.FirstName)
                .From(dbo.Customer)
                .GroupBy(c.FirstName)
                .Having(c.Age.Avg().IsGreaterThan(20))
                .ToString();

            //assert
            actual.Should().BeEquivalentTo(expected, "average column should be created");
        }

    }
}