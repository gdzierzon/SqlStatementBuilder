using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Statements.DML.Extensions;

namespace SqlStatementBuilder.Test.Conditions
{
    [TestClass]
    public class ConditionHelperTests
    {

        [TestMethod]
        public void Combine_ConditionWithAnd()
        {
            //arrange
            var expected = new List<string>() {"one", "AND two", "AND three"};

            //act
            var actual = "one".And("two").And("three").ToList();

            //assert
            actual.Count.Should().Be(3);
            actual[0].Should().Be(expected[0]);
            actual[1].Should().Be(expected[1]);
            actual[2].Should().Be(expected[2]);
        }

        //[TestMethod]
        //public void Combine_ConditionWithAndOr()
        //{
        //    //arrange
        //    var expected = "(col1 = 'one' AND col2 = 'two' OR col3 = 3)";

        //    //act
        //    var actual = Condition.Combine("col1 = 'one'",
        //        Condition.And("col2 = 'two'"),
        //        Condition.Or("col3 = 3"));

        //    //assert
        //    actual.Should().Be(expected);
        //}

        //[TestMethod]
        //public void Combine_WhereCondition()
        //{
        //    //arrange
        //    var expected = "WHERE (one AND two OR three)";

        //    //act
        //    var actual = Condition.Where(
        //                                Condition.Combine("one",
        //                                    Condition.And("two"),
        //                                    Condition.Or("three")
        //                                    )
        //                                );

        //    //assert
        //    actual.Should().Be(expected);
        //}

        //[TestMethod]
        //public void Combine_Dates()
        //{
        //    //arrange
        //    var expected = "('1974-05-22T11:30:00','2001-11-05T01:30:00')";
        //    var date1 = DateTime.Parse("1974-05-22 11:30");
        //    var date2 = DateTime.Parse("2001-11-05 01:30");

        //    //act
        //    var actual = Condition.Combine(date1,date2);

        //    //assert
        //    actual.Should().Be(expected);
        //}

    }
}