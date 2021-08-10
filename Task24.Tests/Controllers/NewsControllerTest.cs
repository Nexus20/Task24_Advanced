using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Task_24.BLL.Interfaces;
using Task_24.BLL.Services;
using Task_24.DAL;
using Task_24.PL.Controllers;

namespace Task_24.Tests.Controllers {

    
    public class NewsControllerTest {

        [SetUp]
        public void Setup() {
        }

        public void IndexViewResultIsNotNull() {
            // Arrange
            var mockNewsService = new Mock<INewsService>();
            mockNewsService.Setup(m => m.GetNews());

            var controller = new NewsController(mockNewsService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
