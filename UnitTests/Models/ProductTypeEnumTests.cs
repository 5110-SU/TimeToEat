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

        // The delete page model to test
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

        [Test]
        public void DisplayName_Valid_ProductType_Undefined_Should_Return_EmptyString()
        {
            // arrange
            var productType = ProductTypeEnum.Undefined;
            var expected = "";

            // act
            var actual = TestModel.DisplayName();

            // assert
            Assert.AreEqual(actual, expected);
        }

        #endregion DisplayName
    }
}
