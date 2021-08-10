using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Task_24.BLL.Interfaces;
using Task_24.BLL.Services;
using Task_24.DAL;
using Task_24.DAL.Entities;
using Task_24.PL.Controllers;

namespace Task_24.Tests.Controllers {
    
    public class HomeControllerTest {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void IndexViewResultIsNotNull() {


            // Arrange
            var mockArticleService = new Mock<IArticleService>();
            mockArticleService.Setup(m => m.GetArticles());

            var mockNewsService = new Mock<INewsService>();
            mockNewsService.Setup(m => m.GetNews());

            var controller = new HomeController(mockArticleService.Object, mockNewsService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
