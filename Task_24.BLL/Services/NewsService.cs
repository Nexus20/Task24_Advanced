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
    public class NewsService : INewsService {

        public IUnitOfWork UnitOfWork { get; }

        public NewsService(IUnitOfWork uow) {
            UnitOfWork = uow;
        }

        public void AddNews(NewsDTO newsDto) {

            var news = new News() {
                ImagePath = newsDto.ImagePath,
                PublicationDate = newsDto.PublicationDate,
                Text = newsDto.Text,
                Title = newsDto.Title
            };

            UnitOfWork.NewsRepository.Create(news);
            UnitOfWork.Save();
        }

        public NewsDTO GetNews(int? id) {

            if (id == null)
                throw new ValidationException("News id is not set", "");
            var news = UnitOfWork.NewsRepository.FindById(id.Value);
            if (news == null)
                throw new ValidationException("News not found", "");

            return new NewsDTO() {
                Id = news.Id,
                ImagePath = news.ImagePath,
                PublicationDate = news.PublicationDate,
                Text = news.Text,
                Title = news.Title
            };

        }

        public IEnumerable<NewsDTO> GetNews() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(UnitOfWork.NewsRepository.Get());
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }
    }
}
