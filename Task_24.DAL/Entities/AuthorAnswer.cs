using System.ComponentModel.DataAnnotations.Schema;

namespace Task_24.DAL.Entities {
    public class AuthorAnswer : BaseEntity {
        [Index("IX_AuthorId_AnswerId", Order = 1, IsUnique = true)]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [Index("IX_AuthorId_AnswerId", Order = 2, IsUnique = true)]
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
