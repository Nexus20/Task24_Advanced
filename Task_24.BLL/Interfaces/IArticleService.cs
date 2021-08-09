using System.Collections;
using System.Collections.Generic;
using Task_24.BLL.DTO;

namespace Task_24.BLL.Interfaces {
    public interface IArticleService {

        void AddArticle(ArticleDTO articleDto);
        ArticleDTO GetArticle(int? id);
        IEnumerable<ArticleDTO> GetArticles();
        void Dispose();

    }
}