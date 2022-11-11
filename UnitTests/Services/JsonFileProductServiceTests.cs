using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework.Internal;

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
            var data = new ProductModel();

            var newData = TestHelper.ProductService.CreateProduct(data);

            // Act
            var result =  TestHelper.ProductService.AddRating(newData.Id, 5);

            var newProduct = TestHelper.ProductService.GetProduct(newData.Id);

            // Reset
            TestHelper.ProductService.DeleteData(newData.Id);

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, newProduct.Ratings.Length);
            Assert.AreEqual(5, newProduct.Ratings.Last());
        }

        /// <summary>
        /// Test AddRating with invalid product ID
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_InvalidID_Should_Return_False()
        {
            // Arrange

            // Act
            bool result = TestHelper.ProductService.AddRating("sdasdasd", 2);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test AddRating with lower than 0 rating and valid product ID
        /// </summary>
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

        /// <summary>
        /// Test AddRating with higher than 5 rating and valid product ID
        /// </summary>
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

        /// <summary>
        /// Test AddRating with empty rating and valid product ID
        /// </summary>
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

        /// <summary>
        /// Tests UpdateData with invalid product ID
        /// </summary>
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

        /// <summary>
        /// Tests UpdateData with valid product ID
        /// </summary>
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

        /// <summary>
        /// Tests DeleteData with valid product ID
        /// </summary>
        [Test]
        public void DeleteData_Valid_ProductID_Should_Return_ProductModelObject()
        {
            // Arrange
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

        /// <summary>
        /// Tests GetProducts
        /// </summary>
        [Test]
        public void GetProducts_Valid_Should_Return_ListOfProduct()
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

        /// <summary>
        /// Tests GetProduct with invalid product ID
        /// </summary>
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

        /// <summary>
        /// Tests GetProduct with valid product ID
        /// </summary>
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

        /// <summary>
        /// Tests CreateProduct
        /// </summary>
        [Test]
        public void CreateProduct_Valid_Save_ProductModelObject_Should_Return_True()
        {
            // Arrange
            var data = new ProductModel();

            // Act
            var newData = TestHelper.ProductService.CreateProduct(data);

            var result = newData.Id != null;

            // Reset
            TestHelper.ProductService.DeleteData(newData.Id);

            // Assert
            Assert.AreEqual(true, result);
        }

        #endregion CreateProduct

        #region GetProductsByTime

        /// <summary>
        /// Tests GetProductsByTime with default time
        /// </summary>
        [Test]
        public void GetProductsByTime_Valid_Default_Return_All_Products()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData();

            var expected = data.Count();

            // Act
            var products = TestHelper.ProductService.GetProductsByTime();

            var actual = products.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests GetProductsByTime exclude products with null hours
        /// </summary>
        [Test]
        public void GetProductsByTime_Valid_With_Null_Hours_Products_Should_Return_List_Of_Products_Without_Null_Hours_Products()
        {
            // Arrange
            var data = TestHelper.ProductService.CreateProduct(new ProductModel()
            {
                Hours = null,
            });

            var id = data.Id;

            // Act
            var products = TestHelper.ProductService.GetProductsByTime(1);

            var actual = products.FirstOrDefault(x => x.Id == id);

            // Assert
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        /// Tests GetProductsByTime exclude products current day of the week that have null hours
        /// </summary>
        [Test]
        public void GetProductsByTime_Valid_With_Day_Null_Hour_Products_Should_Return_List_Of_Products_Without_Day_Null_Hours_Products()
        {
            // Arrange
            var product = new ProductModel();

            product.Hours = new List<int[]>() { null, null, null, null, null, null, null };

            var data = TestHelper.ProductService.CreateProduct(product);

            var id = data.Id;

            // Act
            var products = TestHelper.ProductService.GetProductsByTime(1);

            var actual = products.FirstOrDefault(x => x.Id == id);

            // Assert
            Assert.AreEqual(null, actual);
        }

        /// <summary>
        /// Tests GetProductsByTime include products open after midnight with time within business hours
        /// </summary>
        [Test]
        public void GetProductsByTime_Valid_With_Open_After_Midnight_Should_Return_List_Of_Products_Open()
        {
            // Arrange
            var product = new ProductModel();

            product.Hours = new List<int[]>() {
                new int[] { 21, 2 }, new int[] { 21, 2 }, new int[] { 21, 2 },
                new int[] { 21, 2 }, new int[] { 21, 2 }, new int[] { 21, 2 },
                new int[] { 21, 2 } };

            var data = TestHelper.ProductService.CreateProduct(product);

            var id = data.Id;

            // Act
            var products = TestHelper.ProductService.GetProductsByTime(22);

            var actual = products.FirstOrDefault(x => x.Id == id);

            // Assert
            Assert.AreEqual(product.Id, actual.Id);
        }

        /// <summary>
        /// Tests GetProductsByTime exclude products open after midnight with time after close
        [Test]
        public void GetProductsByTime_Valid_With_Open_After_Midnight_And_Time_After_Midnight_After_Close_Should_Return_List_Of_Products_Open()
        {
            // Arrange
            var product = new ProductModel();

            var product2 = new ProductModel();
            // Create a product that close at 2am
            product.Hours = new List<int[]>() {
                new int[] { 21, 2 }, new int[] { 21, 2 }, new int[] { 21, 2 },
                new int[] { 21, 2 }, new int[] { 21, 2 }, new int[] { 21, 2 },
                new int[] { 21, 2 } 
            };
            // Create a product that still open at 2am
            product2.Hours = new List<int[]>()
            {
                new int[] { 21, 3 }, new int[] { 21, 3 }, new int[] { 21 , 3 },
                new int[] { 21, 3 }, new int[] { 21, 3 }, new int[] { 21 , 3 },
                new int[] { 21, 3 }
            };

            var data = TestHelper.ProductService.CreateProduct(product);

            TestHelper.ProductService.CreateProduct(product2);

            var id = data.Id;

            // Act
            var products = TestHelper.ProductService.GetProductsByTime(2);
            // Only product that sill open at 2 am will be returned
            // so the product created that closed at 1 will not be in the list
            var actual = products.FirstOrDefault(x => x.Id == id);

            // Assert
            Assert.AreEqual(null, actual);
        }

        #endregion GetProductsByTime
    }
}