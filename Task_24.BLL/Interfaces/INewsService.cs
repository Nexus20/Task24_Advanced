using System.Collections;
using System.Collections.Generic;
using Task_24.BLL.DTO;

namespace Task_24.BLL.Interfaces {
    public interface INewsService {

        void AddNews(NewsDTO newsDto);
        NewsDTO GetNews(int? id);
        IEnumerable<NewsDTO> GetNews();
        void Dispose();

    }
}