using ContosoCrafts.WebSite.Pages.Restaurants;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages.Restaurants
{
    public class DetailTests
    {
        #region TestSetup

        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_With_New_Product_ID_Should_Retrieve_Null()
        {
            // Arrange
            var Id = System.Guid.NewGuid().ToString();
            
            // Act
            pageModel.OnGet(Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, pageModel.Product);
        }

        [Test]
        public void OnGet_Valid_With_Existing_Product_ID_Should_Retrieve_Expected_Product()
        {
            // Arrange
            var Product = TestHelper.ProductService.GetProducts().First();

            // Act
            pageModel.OnGet(Product.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(Product.Id, pageModel.Product.Id);
        }
        #endregion OnGet
    }
}
