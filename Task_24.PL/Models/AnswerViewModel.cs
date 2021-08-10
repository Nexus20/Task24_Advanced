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

        [Required]
        [StringLength(32, MinimumLength = 3)]
        [DisplayName("User's name")]
        public string UserName { get; set; }
        public string Comment { get; set; }
        [Required]
        [DisplayName("Site design rate")]
        public string SiteDesign { get; set; }
        [Required]
        [DisplayName("Site usability rate")]
        public string EaseOfUse { get; set; }
        [Required]
        [DisplayName("Genres")]
        public string[] Genres { get; set; }
        [Required]
        [DisplayName("Authors")]
        public string[] Authors { get; set; }
    }
}