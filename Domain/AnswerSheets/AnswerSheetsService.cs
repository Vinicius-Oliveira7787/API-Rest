using System.Collections.Generic;

namespace Domain.AnswerSheets
{
    public class AnswerSheetsService : IAnswerSheetsService
    {
        private readonly IAnswerSheetsRepository _answerSheetsRepository;

        public AnswerSheetsService(IAnswerSheetsRepository answerSheetsRepository)
        {
            _answerSheetsRepository = answerSheetsRepository;
        }

        public CreatedAnswerSheetDTO Create(string name, IList<string> questions)
        {
            var answerSheet = new AnswerSheet(name, questions);
            var AnswerSheetValidation = answerSheet.Validate();

            if (AnswerSheetValidation.isValid)
            {
                _answerSheetsRepository.Add(answerSheet);
                return new CreatedAnswerSheetDTO(answerSheet.Id);
            }

            return new CreatedAnswerSheetDTO(AnswerSheetValidation.errors);
        }
    }
}
