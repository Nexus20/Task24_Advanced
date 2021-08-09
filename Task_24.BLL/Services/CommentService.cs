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
    public class CommentService : ICommentService {

        public UnitOfWork UnitOfWork { get; }

        public CommentService(UnitOfWork uow) {
            UnitOfWork = uow;
        }

        public void AddComment(CommentDTO commentDto) {

            var comment = new Comment() {
                UserName = commentDto.UserName,
                PublicationDate = commentDto.PublicationDate,
                Text = commentDto.Text,
            };

            UnitOfWork.CommentsRepository.Create(comment);
            UnitOfWork.Save();
        }

        public CommentDTO GetComment(int? id) {

            if (id == null)
                throw new ValidationException("Comment id is not set", "");
            var comment = UnitOfWork.CommentsRepository.FindById(id.Value);
            if (comment == null)
                throw new ValidationException("Comment not found", "");

            return new CommentDTO() {
                Id = comment.Id,
                PublicationDate = comment.PublicationDate,
                Text = comment.Text,
                UserName = comment.UserName
            };

        }

        public IEnumerable<CommentDTO> GetComments() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(UnitOfWork.CommentsRepository.Get());
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }
    }
}
