using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Bunit;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("<div class=\"card-body\"><h5 class=\"card-title\">Meet Korean BBQ</h5></div>"));
        }
    }
}