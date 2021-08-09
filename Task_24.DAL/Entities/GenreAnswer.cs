using System.ComponentModel.DataAnnotations.Schema;

namespace Task_24.DAL.Entities {
    public class GenreAnswer : BaseEntity {
        [Index("IX_GenreId_AnswerId", Order = 1, IsUnique = true)]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        [Index("IX_GenreId_AnswerId", Order = 2, IsUnique = true)]
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
