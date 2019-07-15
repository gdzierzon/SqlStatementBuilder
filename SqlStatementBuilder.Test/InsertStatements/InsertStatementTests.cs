using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Test.InsertStatements
{

    [TestClass]
    public class InsertStatementTests
    {

        [TestMethod]
        public void Insert_Header_NoSchema()
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
        public void Insert_Header_WithSchemaExplicit()
        {

            //Arrange
            var expected = "INSERT INTO dbo.Table";

            //Act
            var actual = new Insert("dbo.Table")
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Insert_Header_WithSchemaImplicit()
        {
            //Arrange
            var expected = "INSERT INTO dbo.Table";

            //Act
            var actual = new Insert("dbo.Table")
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Insert_WithColumns()
        {

            //Arrange
            var expected = "INSERT INTO dbo.Table (one, two, three)";

            //Act
            var actual = new Insert("dbo.Table")
                .Columns("one", "two", "three")
                .ToString();

            //Assert
            actual.Should().Be(expected);


        }


        [TestMethod]
        public void Insert_WithValues()
        {

            //Arrange
            var expected = "INSERT INTO dbo.Table VALUES ('one', 1, 'eins')";

            //Act
            var actual = new Insert("dbo.Table")
                .Values("one", 1, "eins")
                .ToString();

            //Assert
            actual.Should().Be(expected);
        }
    }
}
