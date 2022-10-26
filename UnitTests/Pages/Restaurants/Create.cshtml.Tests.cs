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
        public void OnPost_Invalid_Input_Should_Return_Create_Page()
        {
            // arrange
            pageModel.Product = new ProductModel();
            pageModel.ModelState.AddModelError("forcing an error", "forcing an error");

            // act
            pageModel.OnPost();

            // assert
            Assert.AreEqual(pageModel.ModelState.IsValid, false);
        }

        [Test]
        public void OnPost_Null_Image_Should_Return_Create_Page()
        {
            // assign
            var defImg = "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/restaurant-instagram-post-advertisement-design-template-5e3dde31601916fac13b611b18066f52_screen.jpg?ts=1622274831";
            var data = new ProductModel()
            {
                Id = "fortest",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = null,
            };
            pageModel.Product = data;

            // act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(defImg, TestHelper.ProductService.GetProduct(data.Id).Image);

            // reset
            TestHelper.ProductService.DeleteData(data.Id);
        }

        [Test]
        public void OnPost_Null_Url_Should_Return_Create_Page()
        {
            // assign
            var defurl = "https://time-to-eat.azurewebsites.net";
            var data = new ProductModel()
            {
                Id = "fortest",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = null,
                Image = "",
            };
            pageModel.Product = data;

            // act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(defurl, TestHelper.ProductService.GetProduct(data.Id).Url);

            // reset
            TestHelper.ProductService.DeleteData(data.Id);
        }

        [Test]
        public void OnPost_Null_Description_Return_Create_Page()
        {
            // assign
            var defDescription = "Seattle is a food lover’s dream! There are lots of great options so we’ve highlighted some of the best and most unique places to eat in Seattle, Washington.";
            var data = new ProductModel()
            {
                Id = "fortest",
                Title = "Enter Title",
                Description = null,
                Url = "Enter URL",
                Image = "",
            };
            pageModel.Product = data;

            // act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(defDescription, TestHelper.ProductService.GetProduct(data.Id).Description);

            // reset
            TestHelper.ProductService.DeleteData(data.Id);
        }
        #endregion OnPost
    }
}