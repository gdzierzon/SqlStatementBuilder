using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML;
using SqlStatementBuilder.Statements.DML.Conditions;

namespace SqlStatementBuilder.Test.SelectStatements
{
    [TestClass]
    public class SelectJoinTests
    {
        [TestMethod]
        public void Select_SimpleInnerJoin()
        {

            //Arrange
            var expected = "SELECT * FROM Customers AS c INNER JOIN Orders AS o ON c.CustomerId = o.CustomerId";

            //Act
            var actual = new Select("*")
                .From("Customers AS c")
                .Join("Orders AS o")
                .On("c.CustomerId = o.CustomerId")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }
        [TestMethod]
        public void Select_ComplexConditionsInnerJoin()
        {

            //Arrange
            var expected = "SELECT * FROM Customers AS c INNER JOIN Orders AS o ON (c.CustomerId = o.CustomerId AND c.Country = 'USA')";

            //Act
            var actual = new Select("*")
                .From("Customers AS c")
                .Join("Orders AS o")
                .On(Condition.Combine("c.CustomerId = o.CustomerId",Condition.And("c.Country = 'USA'")))
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_SimpleLeftJoin()
        {

            //Arrange
            var expected = "SELECT * FROM Customers AS c LEFT OUTER JOIN Orders AS o ON c.CustomerId = o.CustomerId";

            //Act
            var actual = new Select("*")
                .From("Customers AS c")
                .LeftJoin("Orders AS o")
                .On("c.CustomerId = o.CustomerId")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_SimpleRightJoin()
        {

            //Arrange
            var expected = "SELECT * FROM Customers AS c RIGHT OUTER JOIN Orders AS o ON c.CustomerId = o.CustomerId";

            //Act
            var actual = new Select("*")
                .From("Customers AS c")
                .RightJoin("Orders AS o")
                .On("c.CustomerId = o.CustomerId")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_MultiTableLeftJoin()
        {

            //Arrange
            var expected = "SELECT * FROM Customers AS c LEFT OUTER JOIN Orders AS o ON c.CustomerId = o.CustomerId LEFT OUTER JOIN OrderDetails AS od ON o.OrderId = od.OrderId LEFT OUTER JOIN Products AS p ON od.ProductId = p.ProductId";

            //Act
            var actual = new Select("*")
                .From("Customers AS c")
                .LeftJoin("Orders AS o")
                .On("c.CustomerId = o.CustomerId")
                .LeftJoin("OrderDetails AS od")
                .On("o.OrderId = od.OrderId")
                .LeftJoin("Products AS p")
                .On("od.ProductId = p.ProductId")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }
        
    }
}