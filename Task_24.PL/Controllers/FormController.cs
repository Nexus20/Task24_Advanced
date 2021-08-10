using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_24.BLL.Interfaces;

namespace Task_24.PL.Controllers
{
    public class FormController : Controller {
        private readonly IAnswerService _answerService;

        public FormController(IAnswerService answerService) {
            _answerService = answerService;
        }

        // GET: Form
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}