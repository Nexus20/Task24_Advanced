using System;
using System.ComponentModel.DataAnnotations;

namespace Task_24.DAL.Entities {
    public class Article : BaseEntity {
        [StringLength(100, MinimumLength = 10)]
        public string Title { get; set; }
        public string ImagePath { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 64)]
        public string Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
    }
}
