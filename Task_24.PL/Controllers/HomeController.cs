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
        private readonly INewsService _newsService;

        public HomeController(IArticleService articleService, INewsService newsService) {
            _articleService = articleService;
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index() {

            var newsDtos = _newsService.GetNews().Take(3);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsViewModel>()).CreateMapper();
            ViewBag.LatestNews = mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(newsDtos);

            var articleDtos = _articleService.GetArticles();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>()).CreateMapper();
            var articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);
            return View(articles);
        }
    }
}