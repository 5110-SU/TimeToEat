using ContosoCrafts.WebSite.Pages.Restaurants;
using NUnit.Framework;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Create
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Create_Page()
        {
            // Arrange

            // Act
            pageModel.OnGet("");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet

        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Redirect_To_Detail_Page()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();
            pageModel.Product = data;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Detail"));
        }

        [Test]
        public void OnPost_Invalid_Should_Return_Same_Page()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();
            data.Title = "";
            pageModel.Product = data;

            // Force an invalid error state
            pageModel.ModelState.AddModelError("title-err", "title required");

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;
            
            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Update"));
        }

        [Test]
        public void OnPost_Invalid_Should_Return_Redirect_Index_Page()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();
            data.Id = "not-found-id";
            pageModel.Product = data;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }
        #endregion OnPost
    }
}