using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_24.PL.Models {
    public class ArticleViewModel : BaseViewModel {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PublicationDate { get; set; }
    }
}