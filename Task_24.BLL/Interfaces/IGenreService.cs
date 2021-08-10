using System.Collections;
using System.Collections.Generic;
using Task_24.BLL.DTO;

namespace Task_24.BLL.Interfaces {
    public interface IGenreService {

        void AddGenre(GenreDTO genreDto);
        GenreDTO GetGenre(int? id);
        IEnumerable<GenreDTO> GetGenres();
        void Dispose();

    }
}