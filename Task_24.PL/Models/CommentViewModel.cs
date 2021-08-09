using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_24.PL.Models {
    public class CommentViewModel : BaseViewModel {
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public CommentViewModel() {
            PublicationDate = DateTime.Now;
        }
    }
}