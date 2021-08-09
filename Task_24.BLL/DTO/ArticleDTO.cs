using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_24.BLL.DTO {
    public class ArticleDTO : BaseDTO {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
