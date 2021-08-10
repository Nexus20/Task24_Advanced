using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_24.PL.Models {
    public class CommentViewModel : BaseViewModel {
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 1)]
        public string Text { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PublicationDate { get; set; }

        public CommentViewModel() {
            PublicationDate = DateTime.Now;
        }
    }
}