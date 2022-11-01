using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Restaurants;
using NUnit.Framework;

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
        public void DisplayName_Valid_ProductTypeEnum_Should_Return_String()
        {
            // arrange
            ProductTypeEnum data = new ProductTypeEnum()
            {
                Undefined = 0,  // Default value
                Fastfood = 1,  // Fastfood Restaurant
                Cafe = 5,  // Cafe Restaurant
                BBQ = 130,  // BBQ Restaurant
                FineDining = 55,  // Fine Dining Restaurant
            };

            // act
            TestModel.DisplayName(data);

            // assert
            Assert.AreEqual();
        }

        #endregion DisplayName
    }
}
