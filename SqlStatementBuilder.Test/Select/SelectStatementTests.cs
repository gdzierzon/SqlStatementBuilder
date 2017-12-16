using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Builders;
using SqlStatementBuilder.Statements.DML.Conditions;
using SqlStatementBuilder.Statements.DML.Enumerations;
using Testing.Specificity;

namespace SqlStatementBuilder.Test.Select
{
    [TestClass]
    public class SelectStatementTests
    {

        [TestMethod]
        public void Select()
        {

            //Arrange
            var expected = "SELECT";

            //Act
            var actual = SqlBuilder.Select.ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);
            
        }


        [TestMethod]
        public void Select_All()
        {

            //Arrange
            var expected = "SELECT *";

            //Act
            var actual = SqlBuilder.Select
                .Columns("*")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);
            
        }


        [TestMethod]
        public void Select_MultipleColumns()
        {

            //Arrange
            var expected = "SELECT one, two, three";

            //Act
            var actual = SqlBuilder.Select
                .Columns("one", "two", "three")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);
            
        }


        [TestMethod]
        public void Select_Count()
        {

            //Arrange
            var expected = "SELECT COUNT(*)";

            //Act
            var actual = SqlBuilder.Select
                .Count("*")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);
            
        }


        [TestMethod]
        public void Select_Top10()
        {

            //Arrange
            var expected = "SELECT TOP 10 *";

            //Act
            var actual = SqlBuilder.Select
                .Top(10)
                .Columns("*")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);

        }


        [TestMethod]
        public void Select_TopFromTable()
        {

            //Arrange
            var expected = "SELECT TOP 10 * FROM Table";

            //Act
            var actual = SqlBuilder.Select
                .Top(10)
                .Columns("*")
                .From("Table")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);

        }

        [TestMethod]
        public void Select_Where()
        {

            //Arrange
            var expected = "SELECT * FROM Table WHERE Id = 1";

            //Act
            var actual = SqlBuilder.Select
                .Columns("*")
                .From("Table")
                .Where("Id = 1")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);

        }

        [TestMethod]
        public void Select_WhereAnd()
        {

            //Arrange
            var expected = "SELECT * FROM Table WHERE Id = 1 AND Name = 'Joe'";

            //Act
            var actual = SqlBuilder.Select
                .Columns("*")
                .From("Table")
                .Where("Id = 1")
                .And("Name = 'Joe'")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);

        }

        [TestMethod]
        public void Select_WhereAndOr()
        {

            //Arrange
            var expected = "SELECT * FROM Books WHERE Category = 'cooking' AND (Name LIKE 'Steak%' OR Price > 15)";

            //Act
            var actual = SqlBuilder.Select
                .Columns("*")
                .From("Books")
                .Where("Category = 'cooking'")
                .And(Condition.Combine("Name LIKE 'Steak%'",
                        Condition.Or("Price > 15")
                    ))
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);

        }
    }
}