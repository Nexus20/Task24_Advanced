using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Task_24.BLL.Interfaces;
using Task_24.BLL.Services;
using Task_24.DAL;
using Task_24.PL.Controllers;

namespace Task_24.Tests.Controllers {

    public class GuestControllerTest {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void IndexViewResultIsNotNull() {

            // Arrange
            var mockCommentService = new Mock<ICommentService>();
            mockCommentService.Setup(m => m.GetComments());

            var controller = new GuestController(mockCommentService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
