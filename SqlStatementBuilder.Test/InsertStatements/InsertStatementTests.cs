using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Test.InsertStatements
{

    [TestClass]
    public class InsertStatementTests
    {

        [TestMethod]
        public void Insert_WithHeader()
        {

            //Arrange
            var expected = "INSERT INTO Table";

            //Act
            var actual = new Insert("Table")
                .ToString();

            //Assert
            actual.Should().Be(expected);


        }


        [TestMethod]
        public void Insert_WithColumns()
        {

            //Arrange
            var expected = "INSERT INTO Table (one, two, three)";

            //Act
            var actual = new Insert("Table")
                .Columns("one", "two", "three")
                .ToString();

            //Assert
            actual.Should().Be(expected);


        }


        [TestMethod]
        public void Insert_WithValues()
        {

            //Arrange
            var expected = "INSERT INTO Table VALUES ('one', 1, 'eins')";

            //Act
            var actual = new Insert("Table")
                .Values("'one'", "1", "'eins'")
                .ToString();

            //Assert
            actual.Should().Be(expected);


        }
    }
}
