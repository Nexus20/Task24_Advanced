using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_24.PL.Models {
    /// <summary>
    /// Answer view model
    /// </summary>
    public class AnswerViewModel : BaseViewModel {

        [Required(ErrorMessage = "User's name is required")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "User's name length must be from 3 to 32 characters")]
        [DisplayName("User's name")]
        public string UserName { get; set; }
        public string Comment { get; set; }
        [Required(ErrorMessage = "You have to rate the site design")]
        [DisplayName("Site design rate")]
        public string SiteDesign { get; set; }
        [Required(ErrorMessage = "You have to rate the site usability")]
        [DisplayName("Site usability rate")]
        public string EaseOfUse { get; set; }
        [Required(ErrorMessage = "You have to select your favorite genres")]
        [DisplayName("Genres")]
        public string[] Genres { get; set; }
        [Required(ErrorMessage = "You have to select your favorite authors")]
        [DisplayName("Authors")]
        public string[] Authors { get; set; }
    }
}