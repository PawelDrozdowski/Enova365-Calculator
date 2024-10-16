using NUnit.Framework;
using Rekrutacja.Extensions;
using Rekrutacja.Workers.Enums;
using Rekrutacja.Workers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Rekrutacja.Workers.Template.TemplateWorker;

namespace Rekrutacja.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Should_Return_Zero_If_Empty()
        {
            //Arrange
            string testData = "";

            //Assert
            Assert.AreEqual(0,testData.ConvertToInt());
        }
        [Test]
        public void Should_Return_Correct_Int()
        {
            //Arrange
            string testData = "2";

            //Assert
            Assert.AreEqual(2, testData.ConvertToInt());
        }
        [Test]
        public void Should_ReturnCorrect_Negative()
        {
            //Arrange
            string testData = "-2";

            //Assert
            Assert.AreEqual(-2, testData.ConvertToInt());
        }
        [Test]
        public void Should_Throw_Exception_If_Incorrect_Minus()
        {
            //Arrange
            string testData = "--2";

            //Act
            try
            {
                testData.ConvertToInt();
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
        }
        [Test]
        public void Should_Throw_Exception_If_Non_Minus_Or_Digit_found()
        {
            //Arrange
            string testData = "-2z";
            string testData2 = "-2)";

            //Act
            try
            {
                testData.ConvertToInt();
                testData2.ConvertToInt();
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
        }
    }
}
