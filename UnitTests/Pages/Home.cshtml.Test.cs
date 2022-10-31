using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Home
{
    // Unit Testing class for home page
    // - Testing Methods:
    //      - OnGet()
    public class HomeTests
    {
        #region TestSetup

        // Home model page instace to test 
        public static HomeModel pageModel;

        // Setting up the environment/model 
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new HomeModel()
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        // ModelState.IsValid should return true after OnGet is called 
        // with valid 
        [Test]
        public void OnGet_Valid_Should_Return_Home_Page()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}