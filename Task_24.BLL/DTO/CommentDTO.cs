using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_24.BLL.DTO {
    public class CommentDTO : BaseDTO {
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public CommentDTO() {
            PublicationDate = DateTime.Now;
        }
    }
}
