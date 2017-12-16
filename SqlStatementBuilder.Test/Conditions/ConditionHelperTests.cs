using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML.Conditions;
using Testing.Specificity;

namespace SqlStatementBuilder.Test.Conditions
{
    [TestClass]
    public class ConditionHelperTests
    {
        [TestMethod]
        public void Combine_MultipleConditions()
        {
            //arrange
            var expected = "(one two three)";

            //act
            var actual = Condition.Combine("one", "two", "three");

            //assert
            Specify.That(expected).Should.BeEqualTo(actual);
        }

        [TestMethod]
        public void Combine_ConditionWithAnd()
        {
            //arrange
            var expected = "(one AND two)";

            //act
            var actual = Condition.Combine("one", 
                                            Condition.And("two"));

            //assert
            Specify.That(expected).Should.BeEqualTo(actual);
        }

        [TestMethod]
        public void Combine_ConditionWithAndOr()
        {
            //arrange
            var expected = "(one AND two OR three)";

            //act
            var actual = Condition.Combine("one",
                Condition.And("two"),
                Condition.Or("three"));

            //assert
            Specify.That(expected).Should.BeEqualTo(actual);
        }

        [TestMethod]
        public void Combine_WhereCondition()
        {
            //arrange
            var expected = "WHERE (one AND two OR three)";

            //act
            var actual = Condition.Where(
                                        Condition.Combine("one",
                                            Condition.And("two"),
                                            Condition.Or("three")
                                            )
                                        );

            //assert
            Specify.That(expected).Should.BeEqualTo(actual);
        }

    }
}