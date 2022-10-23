using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;
using NUnit.Framework.Internal;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

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

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());

            // reset
            var toReset = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));
            var ratings = toReset.Ratings.ToList();
            ratings.RemoveAt(toReset.Ratings.Length - 1);
            toReset.Ratings = ratings.ToArray();
        }

        [Test]
        public void AddRating_InValid_Product_InvalidID_Should_Return_False()
        {
            // assign

            // act
            bool result = TestHelper.ProductService.AddRating("sdasdasd", 2);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_Low_Should_Return_False()
        {
            // assign

            // act
            ProductModel data = TestHelper.ProductService.GetAllData().First();
            bool result = TestHelper.ProductService.AddRating(data.Id, -8);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Rating_High_Should_Return_False()
        {
            // assign

            // act
            ProductModel data = TestHelper.ProductService.GetAllData().First();
            bool result = TestHelper.ProductService.AddRating(data.Id, 8);

            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Empty_Rating_Should_Return_True()
        {
            // assign

            // Get the object state before changes applied
            string testID = "Vietnamese";
            ProductModel data = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));

            // act
            bool result = TestHelper.ProductService.AddRating(testID, 5);
            ProductModel dataNewList = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));

            // assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());

            // reset
            ProductModel toReset = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(testID));
            toReset.Ratings = null;
        }
        #endregion AddRating

        #region UpdateData
        [Test]
        public void UpdateData_Invalid_ProductID_Should_Return_Null()
        {
            // assign
            ProductModel data = new ProductModel()
            {
                Id = "does not exist",
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // act
            ProductModel result = TestHelper.ProductService.UpdateData(data);

            // assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void UpdateData_Valid_ProductID_Should_Return_ProductModelObject()
        {
            // assign
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

            // act
            ProductModel result = TestHelper.ProductService.UpdateData(data);

            // assert
            Assert.AreEqual(data.Title, result.Title);
            Assert.AreEqual(data.Description, result.Description);
            Assert.AreEqual(data.Url, result.Url);
            Assert.AreEqual(data.Image, result.Image);
            Assert.AreEqual(data.Quantity, result.Quantity);
            Assert.AreEqual(data.Price, result.Price);
            Assert.AreEqual(data.CommentList, result.CommentList);

            // reset
            ProductModel toReset = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals("Steak House"));
            toReset = oldState;
        }
        #endregion UpdateData

        #region DeleteData
        [Test]
        public void DeleteData_Valid_ProductID_Should_Return_ProductModelObject()
        {
            // assigned
            var oldState = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals("Steak House"));

            // act
            var result = TestHelper.ProductService.DeleteData("Steak House");

            // assert
            Assert.AreEqual(oldState.Title, result.Title);
            Assert.AreEqual(oldState.Description, result.Description);
            Assert.AreEqual(oldState.Url, result.Url);
            Assert.AreEqual(oldState.Image, result.Image);
            Assert.AreEqual(oldState.Quantity, result.Quantity);
            Assert.AreEqual(oldState.Price, result.Price);
            Assert.AreEqual(oldState.CommentList, result.CommentList);

            // reset
            var newCreateData = TestHelper.ProductService.CreateData();
            var newData = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(newCreateData.Id));
            newData = oldState;
        }
        #endregion DeleteData
    }
}