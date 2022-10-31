using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System;

namespace UnitTests.Pages.Product.AddRating
{
    /// <summary>
    /// Unit tests for JsonFileProductService
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        /// <summary>
        /// Set up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        /// <summary>
        /// Test AddRating with null product ID
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test AddRating with invalid product ID
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test AddRating with a rating of 5 and valid product ID
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var testID = "Steak House";
            var data = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));

            // Reset
            var toReset = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));
            var ratings = toReset.Ratings.ToList();
            ratings.RemoveAt(toReset.Ratings.Length - 1);
            toReset.Ratings = ratings.ToArray();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        [Test]
        public void AddRating_InValid_Product_InvalidID_Should_Return_False()
        {
            // Arrange

            // Act
            bool result = TestHelper.ProductService.AddRating("sdasdasd", 2);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_Low_Should_Return_False()
        {
            // Arrange

            // Act
            ProductModel data = TestHelper.ProductService.GetAllData().First();
            bool result = TestHelper.ProductService.AddRating(data.Id, -8);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_High_Should_Return_False()
        {
            // Arrange

            // Act
            ProductModel data = TestHelper.ProductService.GetAllData().First();
            bool result = TestHelper.ProductService.AddRating(data.Id, 8);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Empty_Rating_Should_Return_True()
        {
            // Arrange

            // Get the object state before changes applied
            string testID = "Vietnamese";
            ProductModel data = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));

            // Act
            bool result = TestHelper.ProductService.AddRating(testID, 5);
            ProductModel dataNewList = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));

            // Reset
            ProductModel toReset = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));
            toReset.Ratings = null;

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }
        #endregion AddRating

        #region UpdateData
        [Test]
        public void UpdateData_Invalid_ProductID_Should_Return_Null()
        {
            // Arrange
            ProductModel data = new ProductModel()
            {
                Id = "does not exist",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Act
            ProductModel result = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void UpdateData_Valid_ProductID_Should_Return_ProductModelObject()
        {
            // Arrange
            ProductModel data = new ProductModel()
            {
                Id = "Vietnamese",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // remember old object state for database reset
            ProductModel oldState = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals("Vietnamese"));

            // Act
            ProductModel result = TestHelper.ProductService.UpdateData(data);

            // Reset
            ProductModel toReset = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals("Steak House"));
            toReset = oldState;

            // Assert
            Assert.AreEqual(data.Title, result.Title);
            Assert.AreEqual(data.Description, result.Description);
            Assert.AreEqual(data.Url, result.Url);
            Assert.AreEqual(data.Image, result.Image);
            Assert.AreEqual(data.Quantity, result.Quantity);
            Assert.AreEqual(data.Price, result.Price);
            Assert.AreEqual(data.CommentList, result.CommentList);
        }
        #endregion UpdateData

        #region DeleteData
        [Test]
        public void DeleteData_Valid_ProductID_Should_Return_ProductModelObject()
        {
            // Arrangeed
            var oldState = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals("Steak House"));

            // Act
            var result = TestHelper.ProductService.DeleteData("Steak House");

            // Reset
            var newCreateData = TestHelper.ProductService.CreateData();
            var newData = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(newCreateData.Id));
            newData = oldState;

            // Assert
            Assert.AreEqual(oldState.ToString(), result.ToString());
        }
        #endregion DeleteData

        #region GetProducts
        [Test]
        public void GetProducts_Should_Return_ListOfProduct()
        {
            // Arrange
            var listOfProducts = TestHelper.ProductService.GetProducts();
            var listOfProductsArray = listOfProducts.ToArray();

            // Act
            var result = TestHelper.ProductService.GetProducts();
            var resultArray = result.ToArray();

            // Assert
            for (int i = 0; i < listOfProductsArray.Length; i++)
            {
                Assert.AreEqual(listOfProductsArray[i].ToString(), resultArray[i].ToString());
            }
        }
        #endregion GetProducts

        #region GetProduct
        [Test]
        public void GetProduct_Invalid_ProductID_Should_Return_Null()
        {
            // Arrange
            var ramdomId = System.Guid.NewGuid().ToString();

            // Act
            var result = TestHelper.ProductService.GetProduct(ramdomId);

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void GetProduct_Valid_ProductID_Should_Return_ProductModelObject()
        {
            // Arrange
            var Id = TestHelper.ProductService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ProductService.GetProduct(Id).Id;

            // Assert
            Assert.AreEqual(Id, result);
        }
        #endregion GetProduct

        #region CreateProduct
        [Test]
        public void CreateProduct_Save_ProductModelObject_Should_Return_True()
        {
            // Arrange
            var data = new ProductModel();

            // Act
            var newData = TestHelper.ProductService.CreateProduct(data);
            var result = newData.Id != null;

            // reset
            TestHelper.ProductService.DeleteData(newData.Id);

            // Assert
            Assert.AreEqual(true, result);
        }

        #endregion CreateProduct
    }
}