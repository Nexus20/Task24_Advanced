using System;
using System.ComponentModel.DataAnnotations;

namespace Task_24.DAL.Entities {
    public class Comment : BaseEntity {

        [StringLength(32, MinimumLength = 3)]
        public string UserName { get; set; }
        [StringLength(300, MinimumLength = 1)]
        public string Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        public Comment() {
            PublicationDate = DateTime.Now;
        }
    }
}
