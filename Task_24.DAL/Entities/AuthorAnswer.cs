namespace Task_24.DAL.Entities {
    public class AuthorAnswer : BaseEntity {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
