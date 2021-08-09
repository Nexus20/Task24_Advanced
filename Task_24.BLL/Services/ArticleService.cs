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
    public class ArticleService : IArticleService {

        public IUnitOfWork UnitOfWork { get; }

        public ArticleService(IUnitOfWork uow) {
            UnitOfWork = uow;
        }

        public void AddArticle(ArticleDTO articleDto) {

            var article = new Article() {
                ImagePath = articleDto.ImagePath,
                PublicationDate = articleDto.PublicationDate,
                Text = articleDto.Text,
                Title = articleDto.Title
            };

            UnitOfWork.ArticlesRepository.Create(article);
            UnitOfWork.Save();
        }

        public ArticleDTO GetArticle(int? id) {

            if (id == null)
                throw new ValidationException("Article id is not set", "");
            var article = UnitOfWork.ArticlesRepository.FindById(id.Value);
            if (article == null)
                throw new ValidationException("Article not found", "");

            return new ArticleDTO() {
                Id = article.Id,
                ImagePath = article.ImagePath,
                PublicationDate = article.PublicationDate,
                Text = article.Text,
                Title = article.Title
            };

        }

        public IEnumerable<ArticleDTO> GetArticles() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(UnitOfWork.ArticlesRepository.Get());
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }
    }
}
