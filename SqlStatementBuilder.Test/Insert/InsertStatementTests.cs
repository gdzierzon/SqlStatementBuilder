using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStatementBuilder.Builders;
using Testing.Specificity;

namespace SqlStatementBuilder.Test.Insert
{

    [TestClass]
    public class InsertStatementTests
    {

        [TestMethod]
        public void Create_Insert_WithInsertHeader()
        {

            //Arrange
            var expected = "INSERT INTO Table";

            //Act
            var actual = SqlBuilder.Insert("Table")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);


        }


        [TestMethod]
        public void Create_Insert_WithColumns()
        {

            //Arrange
            var expected = "INSERT INTO Table (one, two, three)";

            //Act
            var actual = SqlBuilder.Insert("Table")
                .Columns("one", "two", "three")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);


        }


        [TestMethod]
        public void Create_Insert_WithValues()
        {

            //Arrange
            var expected = "INSERT INTO Table VALUES ('one', 1, 'eins')";

            //Act
            var actual = SqlBuilder.Insert("Table")
                .Values("'one'", "1", "'eins'")
                .ToString();

            //Assert
            Specify.That(actual).Should.BeEqualTo(expected);


        }
    }
}
