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
    /// <summary>
    /// Unit test for product type enum 
    /// </summary>
    internal class ProductTypeEnumTests
    {
        #region TestSetup

        /// <summary>
        /// Setup the test environment for the TestModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
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
            var actual = ProductTypeEnumExtensions.DisplayName(productType);

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
            var actual = ProductTypeEnumExtensions.DisplayName(productType);

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
            var actual = ProductTypeEnumExtensions.DisplayName(productType);

            // assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test DisplayName function with enum type BBQ
        /// </summary>
        [Test]
        public void DisplayName_ProductType_BBQ_Should_Return_BBQ()
        {
            // arrange
            var productType = ProductTypeEnum.BBQ;
            var expected = "BBQ";

            // act
            var actual = ProductTypeEnumExtensions.DisplayName(productType);

            // assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test DisplayName function with enum type FineDining
        /// </summary>
        [Test]
        public void DisplayName_ProductType_FineDining_Should_Return_FineDining()
        {
            // arrange
            var productType = ProductTypeEnum.FineDining;
            var expected = "FineDining";

            // act
            var actual = ProductTypeEnumExtensions.DisplayName(productType);

            // assert
            Assert.AreEqual(actual, expected);
        }

        #endregion DisplayName
    }
}
