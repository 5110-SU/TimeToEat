using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Restaurants;
using NUnit.Framework;
using static NUnit.Framework.Internal.OSPlatform;

namespace UnitTests.Models
{
    internal class ProductTypeEnumTests
    {
        #region TestSetup

        // The ProductTypeEnum type test model to test
        public static ProductTypeEnum TestModel;

        /// <summary>
        /// Setup the test environment for the TestModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            TestModel = new ProductTypeEnum()
            {

            };
        }

        #endregion TestSetup

        #region DisplayName

        /// <summary>
        /// Test DisplayName function with enum type undefined
        /// </summary>
        [Test]
        public void DisplayName_ProductType_Undefined_Should_Return_EmptyString()
        {
            // arrange
            var productType = ProductTypeEnum.Undefined;
            var expected = "";

            // act
            var actual = TestModel.DisplayName();

            // assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test DisplayName function with enum type Fastfood
        /// </summary>
        [Test]
        public void DisplayName_ProductType_Fastfood_Should_Return_Fastfood()
        {
            // arrange
            var productType = ProductTypeEnum.Fastfood;
            var expected = "Fastfood";

            // act
            var actual = TestModel.DisplayName();

            // assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test DisplayName function with enum type Cafe
        /// </summary>
        [Test]
        public void DisplayName_ProductType_Cafe_Should_Return_Cafe()
        {
            // arrange
            var productType = ProductTypeEnum.Cafe;
            var expected = "Cafe";

            // act
            var actual = TestModel.DisplayName();

            // assert
            Assert.AreEqual(actual, expected);
        }

        #endregion DisplayName
    }
}
