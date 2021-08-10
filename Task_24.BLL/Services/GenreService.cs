using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Task_24.BLL.DTO;
using Task_24.BLL.Infrastructure;
using Task_24.BLL.Interfaces;
using Task_24.DAL;
using Task_24.DAL.Entities;

namespace Task_24.BLL.Services {
    public class GenreService : IGenreService {

        public IUnitOfWork UnitOfWork { get; }

        public GenreService(IUnitOfWork uow) {
            UnitOfWork = uow;
        }

        public void AddGenre(GenreDTO genreDto) {

            var genre = new Genre() {
                Name = genreDto.Name
            };

            UnitOfWork.GenresRepository.Create(genre);
            UnitOfWork.Save();
        }

        public GenreDTO GetGenre(int? id) {

            if (id == null)
                throw new ValidationException("Genre id is not set", "");
            var genre = UnitOfWork.GenresRepository.FindById(id.Value);
            if (genre == null)
                throw new ValidationException("Genre not found", "");

            return new GenreDTO() {
                Id = genre.Id,
                Name = genre.Name
            };

        }

        public IEnumerable<GenreDTO> GetGenres() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(UnitOfWork.GenresRepository.Get());
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }
    }
}
