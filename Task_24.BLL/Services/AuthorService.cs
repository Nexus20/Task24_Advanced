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
    public class AuthorService : IAuthorService {

        public IUnitOfWork UnitOfWork { get; }

        public AuthorService(IUnitOfWork uow) {
            UnitOfWork = uow;
        }

        public void AddAuthor(AuthorDTO authorDto) {

            var author = new Author() {
                Name = authorDto.Name
            };

            UnitOfWork.AuthorsRepository.Create(author);
            UnitOfWork.Save();
        }

        public AuthorDTO GetAuthor(int? id) {

            if (id == null)
                throw new ValidationException("Author id is not set", "");
            var author = UnitOfWork.AuthorsRepository.FindById(id.Value);
            if (author == null)
                throw new ValidationException("Author not found", "");

            return new AuthorDTO() {
                Id = author.Id,
                Name = author.Name
            };

        }

        public IEnumerable<AuthorDTO> GetAuthors() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(UnitOfWork.AuthorsRepository.Get());
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }
    }
}
