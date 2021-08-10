using System.Collections;
using System.Collections.Generic;
using Task_24.BLL.DTO;

namespace Task_24.BLL.Interfaces {
    public interface IAuthorService {

        void AddAuthor(AuthorDTO authorDto);
        AuthorDTO GetAuthor(int? id);
        IEnumerable<AuthorDTO> GetAuthors();
        void Dispose();

    }
}