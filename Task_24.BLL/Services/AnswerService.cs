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
    public class AnswerService : IAnswerService {

        public IUnitOfWork UnitOfWork { get; }

        public AnswerService(IUnitOfWork uow) {
            UnitOfWork = uow;
        }

        public void AddAnswer(AnswerDTO answerDto) {

            var answer = new Answer() {
                Comment = answerDto.Comment,
                EaseOfUse = answerDto.EaseOfUse,
                SiteDesign = answerDto.SiteDesign,
                UserName = answerDto.UserName
            };

            UnitOfWork.AnswersRepository.Create(answer);
            UnitOfWork.Save();
        }

        public AnswerDTO GetAnswer(int? id) {

            if (id == null)
                throw new ValidationException("Answer id is not set", "");
            var answer = UnitOfWork.AnswersRepository.FindById(id.Value);
            if (answer == null)
                throw new ValidationException("Answer not found", "");

            return new AnswerDTO() {
                Id = answer.Id,
                Comment = answer.Comment,
                EaseOfUse = answer.EaseOfUse,
                SiteDesign = answer.SiteDesign,
                UserName = answer.UserName
            };

        }

        public IEnumerable<AnswerDTO> GetAnswers() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Answer>, List<AnswerDTO>>(UnitOfWork.AnswersRepository.Get());
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }
    }
}
