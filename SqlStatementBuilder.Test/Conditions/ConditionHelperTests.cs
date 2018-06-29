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

        [TestMethod]
        public void Combine_ConditionWithAndOr()
        {
            //arrange
            var expected = new List<string>() {"col1 = 'one'", "AND col2 = 'two'", "OR col3 = 3"};

            //act
            var actual = "col1 = 'one'"
                    .And("col2 = 'two'")
                    .Or("col3 = 3").ToList();
            
            //assert
            actual.Count.Should().Be(3);
            actual[0].Should().Be(expected[0]);
            actual[1].Should().Be(expected[1]);
            actual[2].Should().Be(expected[2]);
        }
        

    }
}