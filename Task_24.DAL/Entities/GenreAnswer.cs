namespace Task_24.DAL.Entities {
    public class GenreAnswer : BaseEntity {
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
