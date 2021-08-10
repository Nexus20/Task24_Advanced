using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Task_24.BLL.DTO;
using Task_24.BLL.Interfaces;
using Task_24.PL.Models;

namespace Task_24.PL.Controllers
{
    public class NewsController : Controller
    {

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService) {
            _newsService = newsService;
        }

        // GET: News
        /// <summary>
        /// This action handles GET-requests
        /// </summary>
        /// <returns>Returns index view with news list</returns>
        [HttpGet]
        public ActionResult Index() {

            var newsDtos = _newsService.GetNews();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDTO, NewsViewModel>()).CreateMapper();
            var news = mapper.Map<IEnumerable<NewsDTO>, List<NewsViewModel>>(newsDtos);

            return View(news);
        }
    }
}