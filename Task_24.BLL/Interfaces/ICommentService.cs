using System.Collections;
using System.Collections.Generic;
using Task_24.BLL.DTO;

namespace Task_24.BLL.Interfaces {
    public interface ICommentService {

        void AddComment(CommentDTO commentDto);
        CommentDTO GetComment(int? id);
        IEnumerable<CommentDTO> GetComments();
        void Dispose();

    }
}