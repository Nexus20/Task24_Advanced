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
    public class GuestController : Controller {

        private readonly ICommentService _commentService;

        public GuestController(ICommentService commentService) {
            _commentService = commentService;
        }

        // GET: Guest
        [HttpGet]
        public ActionResult Index() {

            var commentDtos = _commentService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            ViewBag.Comments = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);

            return View();
        }

        /// <summary>
        /// This action handles POST-requests
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Returns index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CommentViewModel comment) {

            try {

                if (string.IsNullOrEmpty(comment.UserName)) {
                    ModelState.AddModelError("UserName", "Incorrect username");
                }
                else if (comment.UserName.Length < 3) {
                    ModelState.AddModelError("UserName", "Username is too short");
                }
                else if (comment.UserName.Length > 32) {
                    ModelState.AddModelError("UserName", "Username is too long");
                }

                if (string.IsNullOrEmpty(comment.Text)) {
                    ModelState.AddModelError("Text", "Incorrect comment");
                }
                else if (comment.Text.Length > 300) {
                    ModelState.AddModelError("Text", "Comment is too long");
                }

                if (ModelState.IsValid) {

                    _commentService.AddComment(new CommentDTO() {
                        Text = comment.Text,
                        UserName = comment.UserName
                    });

                    return Content("Comment added");
                }

            }
            catch (DataException dex) {
                //TODO: Log the error (dex variable)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            var commentDtos = _commentService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            ViewBag.Comments = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);

            return View(comment);
        }
    }
}