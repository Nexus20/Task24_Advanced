using System;
using System.ComponentModel.DataAnnotations;

namespace Task_24.DAL.Entities {
    public class News : BaseEntity {
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 10)]
        public string ImagePath { get; set; }
        [StringLength(short.MaxValue, MinimumLength = 64)]
        public string Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
    }
}
