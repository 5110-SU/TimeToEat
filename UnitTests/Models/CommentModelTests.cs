using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages;
using NUnit.Framework;

namespace UnitTests.Models
{
    internal class CommentModelTests
    {
        #region TestSetup

        /// Comment model instace to test 
        public static CommentModel TestModel;

        /// <summary>
        /// Set up the test environmenmt
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            TestModel = new CommentModel()
            {

            };
        }

        #endregion TestSetup

        #region TestID

        /// <summary>
        /// unit test on Id set and get
        /// </summary>
        [Test]
        public void SetGetId_Should_Return_Id()
        {
            // arrange
            var newId = Guid.NewGuid().ToString();

            // act
            TestModel.Id = newId;

            // assert
            Assert.AreEqual(newId, TestModel.Id);
        }

        #endregion TestID

        #region TestComment

        /// <summary>
        /// unit test on Comment set and get
        /// </summary>
        [Test]
        public void SetGetComment_Should_Return_Comment()
        {
            // arrange
            var newComment = "test";

            // act
            TestModel.Comment = newComment;

            // assert
            Assert.AreEqual(newComment, TestModel.Comment);
        }

        #endregion TestComment
    }
}
