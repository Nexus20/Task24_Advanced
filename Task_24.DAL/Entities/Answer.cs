using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_24.DAL.Entities {
    public class Answer : BaseEntity {
        [StringLength(32, MinimumLength = 3)]
        public string UserName { get; set; }
        public string Comment { get; set; }
        public string SiteDesign { get; set; }
        public string EaseOfUse { get; set; }
        public virtual ICollection<GenreAnswer> GenreAnswers { get; set; }
        public virtual ICollection<AuthorAnswer> AuthorAnswers { get; set; }
    }
}
