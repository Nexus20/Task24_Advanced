using System;

namespace Task_24.DAL.Entities {
    public class Comment : BaseEntity {

        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public Comment() {
            PublicationDate = DateTime.Now;
        }
    }
}
