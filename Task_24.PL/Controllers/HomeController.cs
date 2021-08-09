using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Task_24.BLL.DTO;
using Task_24.BLL.Interfaces;
using Task_24.PL.Models;

namespace Task_24.PL.Controllers {
    public class HomeController : Controller {

        private readonly IArticleService _articleService;

        public HomeController(IArticleService articleService) {
            _articleService = articleService;
        }

        [HttpGet]
        public ActionResult Index() {

            var articleDtos = _articleService.GetArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
            var articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);
            return View(articles);
        }
    }
}