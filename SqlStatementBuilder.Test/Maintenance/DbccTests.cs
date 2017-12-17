using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.Maintenance;
using Testing.Specificity;

namespace SqlStatementBuilder.Test.Maintenance
{
    [TestClass]
    public class DbccTests
    {
        [TestMethod]
        public void Reseed_TableWithDefaultSeed()
        {
            //arrange
            var expected = "DBCC CHECKIDENT('dbo.Table', RESEED)";

            //act
            var query = Dbcc.Reseed("dbo.Table");

            //assert
            Specify.That(expected).Should.BeEqualTo(query);
        }
        [TestMethod]
        public void Reseed_TableWithNewSeed()
        {
            //arrange
            var expected = "DBCC CHECKIDENT('dbo.Table', RESEED, 1)";

            //act
            var query = Dbcc.Reseed("dbo.Table", 1);

            //assert
            Specify.That(expected).Should.BeEqualTo(query);
        }
    }
}