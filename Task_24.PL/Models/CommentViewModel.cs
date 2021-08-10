using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_24.PL.Models {
    public class CommentViewModel : BaseViewModel {
        [Required(ErrorMessage = "User's name is required")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "User's name length must be from 3 to 32 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Comment length must be from 1 to 300 characters")]
        public string Text { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PublicationDate { get; set; }

        public CommentViewModel() {
            PublicationDate = DateTime.Now;
        }
    }
}