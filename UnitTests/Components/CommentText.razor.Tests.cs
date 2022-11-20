using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;
using Bunit;
using System.Linq;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit test for CommentText razor component
    /// </summary>
    public class CommentTextTests : BunitTestContext
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

        #region CommentText 

        /// <summary>
        /// Unit test on CommentText component with default argument
        /// </summary>
        [Test]
        public void CommentText_Valid_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            var text = "This is a test comment";

            // Create a test Comment
            var comment = new CommentModel();
            comment.Comment = text;
            
            // pre-render the component
            var page = RenderComponent<CommentText>(
                parameters => parameters.Add(p => p.Comment, comment));

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains(text));
        }
        
        #endregion CommentText
    }
}