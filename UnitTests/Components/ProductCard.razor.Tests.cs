using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit test for ProductCard razor component
    /// </summary>
    public class ProductCardTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Initialize unit test 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region ProductCard 

        /// <summary>
        /// Unit test on ProductCard with default argument
        /// </summary>
        [Test]
        public void ProductCard_Valid_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            var title = "This is a test title";

            var description = "This is a test description";

            // Create a test product with preset title
            var product = TestHelper.ProductService.CreateProduct(
                new ProductModel() 
                { Title = title, Description = description });
            
            // pre-render the component
            var page = RenderComponent<ProductCard>(parameters => parameters.Add(p => p.Product, product));

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains(title));
        }

        #endregion ProductCard
    }
}