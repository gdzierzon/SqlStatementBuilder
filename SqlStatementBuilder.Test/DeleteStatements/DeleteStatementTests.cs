using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML;

namespace SqlStatementBuilder.Test.DeleteStatements
{
    [TestClass]
    public class DeleteStatementTests
    {
        [TestMethod]
        public void Delete_WithTableName()
        {
            //arrange
            var expected = "DELETE FROM Table";

            //act
            var query = new Delete("Table")
                .ToString();

            //assert
            query.Should().Be(expected);
        }

        [TestMethod]
        public void Delete_TableWithWhere()
        {
            //arrange
            var expected = "DELETE FROM Products WHERE Price > 100";

            //act
            var query = new Delete("Products")
                .Where("Price > 100")
                .ToString();

            //assert
            query.Should().Be(expected);
        }

    }
}