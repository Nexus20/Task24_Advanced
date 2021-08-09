using System;

namespace Task_24.DAL.Entities {
    public class Article : BaseEntity {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
