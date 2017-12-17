using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Builders;
using Testing.Specificity;

namespace SqlStatementBuilder.Test.Delete
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
            var query = SqlBuilder.Delete("Table")
                .ToString();

            //assert
            Specify.That(query).Should.BeEqualTo(expected);
        }
        [TestMethod]
        public void Delete_TableWithWhere()
        {
            //arrange
            var expected = "DELETE FROM Products WHERE Price > 100";

            //act
            var query = SqlBuilder.Delete("Products")
                .Where("Price > 100")
                .ToString();

            //assert
            Specify.That(query).Should.BeEqualTo(expected);
        }

    }
}