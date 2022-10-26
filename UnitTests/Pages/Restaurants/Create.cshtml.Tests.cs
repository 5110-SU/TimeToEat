using ContosoCrafts.WebSite.Pages.Restaurants;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace UnitTests.Pages.Create
{
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Create_Empty_Product_Model()
        {
            // Arrange
            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, pageModel.Product.Id);
        }
        #endregion OnGet

        #region OnPost
         [Test]
        public void OnPost_Invalid_Should_Produce_Invalid_Model_State()
        {
            // Arrange
            pageModel.Product = new ProductModel();

            // Force an invalid error state
            pageModel.ModelState.AddModelError("title-err", "title empty");

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }


        [Test]
        public void OnPost_Valid_Empty_Product_Should_Redirect_To_Detail_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel();

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Product.Id != null);
            Assert.AreEqual(true, result.PageName.Contains("Detail"));
        }

        #endregion OnPost
    }
}