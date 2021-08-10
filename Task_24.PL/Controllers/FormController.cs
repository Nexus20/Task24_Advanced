using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Task_24.BLL.DTO;
using Task_24.BLL.Interfaces;
using Task_24.PL.Models;

namespace Task_24.PL.Controllers
{
    public class FormController : Controller {
        private readonly IAnswerService _answerService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public FormController(IAnswerService answerService, IAuthorService authorService, IGenreService genreService) {
            _answerService = answerService;
            _authorService = authorService;
            _genreService = genreService;
        }

        // GET: Form
        [HttpGet]
        public ActionResult Index()
        {

            var genreDtos = _genreService.GetGenres();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>()).CreateMapper();
            ViewBag.Genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(genreDtos).ToDictionary(g => g.Id, g => g.Name); ;

            var authorDtos = _authorService.GetAuthors();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            ViewBag.Authors = mapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(authorDtos).ToDictionary(a => a.Id, a => a.Name); ;

            ViewBag.SiteDesignRateVariants = new List<string> { "1", "2", "3", "4", "5" };
            ViewBag.EaseOfUseRateVariants = new List<string> { "1", "2", "3", "4", "5" };

            return View();
        }

        /// <summary>
        /// This action handles POST requests   
        /// </summary>
        /// <param name="answer"></param>
        /// <returns>Redirects to answers view if model is valid or returns index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AnswerViewModel answer) {

            try {

                if (string.IsNullOrEmpty(answer.UserName)) {
                    ModelState.AddModelError("UserName", "Incorrect username");
                }
                else if (answer.UserName.Length < 3) {
                    ModelState.AddModelError("UserName", "Username is too short");
                }
                else if (answer.UserName.Length > 32) {
                    ModelState.AddModelError("UserName", "Username is too long");
                }

                if (string.IsNullOrEmpty(answer.EaseOfUse)) {
                    ModelState.AddModelError("EaseOfUse", "Rate site usability");
                }

                if (string.IsNullOrEmpty(answer.SiteDesign)) {
                    ModelState.AddModelError("SiteDesign", "Rate site design");
                }

                if (answer.Authors.All(a => a == "false")) {
                    ModelState.AddModelError("Authors", "Select authors");
                }

                if (answer.Genres.All(a => a == "false")) {
                    ModelState.AddModelError("Genres", "Select genres");
                }

                if (ModelState.IsValid) {

                    var answerDto = new AnswerDTO() {
                        Comment = answer.Comment,
                        EaseOfUse = answer.EaseOfUse,
                        SiteDesign = answer.SiteDesign,
                        UserName = answer.UserName,
                    };

                    _answerService.AddAnswer(answerDto);

                    return View("Answers", answer);
                }

            }
            catch (DataException dex) {
                //TODO: Log the error (dex variable)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            var genreDtos = _genreService.GetGenres();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>()).CreateMapper();
            ViewBag.Genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(genreDtos).ToDictionary(g => g.Id, g => g.Name); ;

            var authorDtos = _authorService.GetAuthors();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, AuthorViewModel>()).CreateMapper();
            ViewBag.Authors = mapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(authorDtos).ToDictionary(a => a.Id, a => a.Name); ;

            ViewBag.SiteDesignRateVariants = new List<string> { "1", "2", "3", "4", "5" };
            ViewBag.EaseOfUseRateVariants = new List<string> { "1", "2", "3", "4", "5" };
            return View(answer);
        }
    }
}