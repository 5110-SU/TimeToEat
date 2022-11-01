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
    }
}
