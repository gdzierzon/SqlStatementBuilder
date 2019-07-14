using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Scafolding;
using SqlStatementBuilder.Statements.DML;
using SqlStatementBuilder.Test.TestDatabase;
using SqlStatementBuilder.Test.TestDatabase.Tables;

namespace SqlStatementBuilder.Test.InsertStatements
{
    [TestClass]
    public class Insert_WithSchemaAndBuilder_Tests: SqlBuilder
    {
        private Dbo dbo;

        [TestInitialize]
        public void Initialize()
        {
            dbo = new Dbo();
        }

        [TestMethod]
        public void Insert_Header()
        {

            //Arrange
            var expected = "INSERT INTO [dbo].[Product]";

            //Act
            var actual = Insert(dbo.Product)
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Insert_TableAndColumns()
        {
            Product p = dbo.Product;

            //Arrange
            var expected = "INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [Price])";

            //Act
            var actual = Insert(dbo.Product)
                .Columns(p.ProductId
                    , p.ProductName
                    , p.Price)
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Insert_TableColumnsAndValues()
        {
            Product p = dbo.Product;

            //Arrange
            var expected = "INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [Price]) VALUES (1, 'Marker', 3.95)";

            //Act
            var actual = Insert(dbo.Product)
                .Columns(p.ProductId
                    , p.ProductName
                    , p.Price)
                .Values(1,"Marker", 3.95)
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Insert_FromSelect()
        {
            Product p = dbo.Product;

            //Arrange
            var expected = "INSERT INTO [dbo].[Product] ([ProductId], [ProductName], [Price]) SELECT [ProductId], [ProductName], [Price] FROM [dbo].[Product]";

            //Act
            var actual = Insert(dbo.Product)
                .Columns(p.ProductId
                    , p.ProductName
                    , p.Price)
                .Select(
                    new Select(p.ProductId
                            ,p.ProductName
                            ,p.Price
                        )
                        .From(p)
                    )
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

    }
}