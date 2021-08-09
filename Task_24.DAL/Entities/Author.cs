using System.Collections.Generic;

namespace Task_24.DAL.Entities {
    public class Author : BaseEntity {
        public string Name { get; set; }
        public virtual ICollection<AuthorAnswer> AuthorAnswers { get; set; }
    }
}
