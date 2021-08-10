using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Task_24.BLL.Interfaces;
using Task_24.BLL.Services;
using Task_24.DAL;
using Task_24.PL.Controllers;

namespace Task_24.Tests.Controllers {

    public class FormControllerTest {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void IndexViewResultIsNotNull() {
            // Arrange

            var mockAnswerService = new Mock<IAnswerService>();
            mockAnswerService.Setup(m => m.GetAnswers());

            var mockAuthorService = new Mock<IAuthorService>();
            mockAuthorService.Setup(m => m.GetAuthors());

            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(m => m.GetGenres());

            var controller = new FormController(mockAnswerService.Object, mockAuthorService.Object, mockGenreService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
