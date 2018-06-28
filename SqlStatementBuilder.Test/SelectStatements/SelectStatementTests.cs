using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML;
using SqlStatementBuilder.Statements.DML.Extensions;

namespace SqlStatementBuilder.Test.SelectStatements
{
    [TestClass]
    public class SelectStatementTests
    {
        [TestMethod]
        public void Select_All()
        {

            //Arrange
            var expected = "SELECT *";

            //Act
            var actual = new Select("*")
                .ToString();

            //Assert
            actual.Should().Be(expected);
            
        }


        [TestMethod]
        public void Select_MultipleColumns()
        {

            //Arrange
            var expected = "SELECT one, two, three";

            //Act
            var actual = new Select(
                    "one", 
                    "two", 
                    "three"
                 )
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_Count()
        {

            //Arrange
            var expected = "SELECT COUNT(*)";

            //Act
            var actual = new Select()
                .Count("*")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_Sum()
        {

            //Arrange
            var expected = "SELECT SUM(Price)";

            //Act
            var actual = new Select()
                .Sum("Price")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_Average()
        {

            //Arrange
            var expected = "SELECT AVG(Price)";

            //Act
            var actual = new Select()
                .Average("Price")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_MinAndMax()
        {

            //Arrange
            var expected = "SELECT MIN(Price), MAX(Price)";

            //Act
            var actual = new Select()
                .Min("Price")
                .Max("Price")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }


        [TestMethod]
        public void Select_Top10()
        {

            //Arrange
            var expected = "SELECT TOP 10 *";

            //Act
            var actual = new Select()
                .Top(10)
                .Columns("*")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }


        [TestMethod]
        public void Select_TopFromTable()
        {

            //Arrange
            var expected = "SELECT TOP 10 * FROM Table";

            //Act
            var actual = new Select()
                .Top(10)
                .Columns("*")
                .From("Table")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_Where()
        {

            //Arrange
            var expected = "SELECT * FROM Table WHERE Id = 1";

            //Act
            var actual = new Select("*")
                .From("Table")
                .Where("Id = 1")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereAnd()
        {

            //Arrange
            var expected = "SELECT * FROM Table WHERE Id = 1 AND Name = 'Joe'";

            //Act
            var actual = new Select("*")
                .From("Table")
                .Where("Id = 1")
                .And("Name = 'Joe'")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereAndOr()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE Category = 'cooking' AND (Name LIKE 'Steak%' OR Price > 15)";

            //Act
            var actual = new Select("*")
                .From("Books")
                .Where("Category = 'cooking'")
                .And("Name LIKE 'Steak%'".Or("Price > 15"))
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereWithConstants()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE (Category = 'cooking' AND Price > 15)";

            //Act
            var actual = new Select("*")
                .From("Books")
                .Where("Category = 'cooking'",
                    "AND",
                    "Price > 15")
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereWithEqualityStringComparison()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE Category = 'cooking'";

            //Act
            var actual = new Select("*")
                .From("Books")
                .Where("Category".IsEqualTo("cooking"))
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereWithEqualityNumericComparison()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE Price = 15.5";

            //Act
            var actual = new Select("*")
                .From("Books")
                .Where("Price".IsEqualTo(15.5))
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereWithComparisons()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE (Category = 'cooking' AND Price > 15)";

            //Act
            var actual = new Select("*")
                .From("Books")
                .Where(
                    "Category".IsEqualTo("cooking")
                    .And("Price".IsGreaterThan(15))
                ).ToString();

            //Assert
            actual.Should().Be(expected);

        }

        [TestMethod]
        public void Select_WhereAndOr_UsingComparisonExtensions()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE Category = 'cooking' AND (Name LIKE 'Steak%' OR Price > 15)";

            //Act
            var actual = new Select("*")
                .From("Books")
                .Where("Category".IsEqualTo("cooking"))
                .And(
                    "Name".IsLike("Steak%")
                    .Or("Price".IsGreaterThan(15))
                )
                .ToString();

            //Assert
            actual.Should().Be(expected);

        }
    }
}