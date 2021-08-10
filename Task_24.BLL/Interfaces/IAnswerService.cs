using System.Collections;
using System.Collections.Generic;
using Task_24.BLL.DTO;

namespace Task_24.BLL.Interfaces {
    public interface IAnswerService {

        void AddAnswer(AnswerDTO answerDto);
        AnswerDTO GetAnswer(int? id);
        IEnumerable<AnswerDTO> GetAnswers();
        void Dispose();

    }
}