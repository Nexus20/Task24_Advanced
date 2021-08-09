using System.Collections.Generic;

namespace Task_24.DAL.Entities {
    public class Genre : BaseEntity {
        public string Name { get; set; }
        public virtual ICollection<GenreAnswer> GenreAnswers { get; set; }
    }
}
