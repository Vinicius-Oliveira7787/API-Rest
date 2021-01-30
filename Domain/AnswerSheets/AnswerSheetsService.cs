using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.AnswerSheets
{
    public class AnswerSheetsService : IAnswerSheetsService
    {
        private readonly IAnswerSheetsRepository _answerSheetsRepository;

        public AnswerSheetsService(IAnswerSheetsRepository answerSheetsRepository)
        {
            _answerSheetsRepository = answerSheetsRepository;
        }

        public CreatedAnswerSheetDTO Create(string[] questions)
        {
            var answerSheet = new AnswerSheet(questions);
            var AnswerSheetValidation = answerSheet.Validate();

            if (AnswerSheetValidation.isValid)
            {
                _answerSheetsRepository.Add(answerSheet);
                return new CreatedAnswerSheetDTO(answerSheet.Id);
            }

            return new CreatedAnswerSheetDTO(AnswerSheetValidation.errors);
        }

        public AnswerSheet GetById(Guid id) {
            return _answerSheetsRepository.Get(id);
        }

        public string[] GetQuestions(Guid id)
        {
            var answerSheet =_answerSheetsRepository.Get(id);
            if (answerSheet == null)
            {
                return null;
            }
            
            return answerSheet.Questions.ToArray();
        }
    }
}
