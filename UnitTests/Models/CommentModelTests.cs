using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages;
using NUnit.Framework;

namespace UnitTests.Models
{
    internal class CommentModelTests
    {
        #region TestSetup

        /// Comment model instace to test 
        public static CommentModel TestModel;

        /// <summary>
        /// Set up the test environmenmt
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            TestModel = new CommentModel()
            {

            };
        }

        #endregion TestSetup
    }
}
