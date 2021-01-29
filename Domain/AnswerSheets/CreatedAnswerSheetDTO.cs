using System;
using System.Collections.Generic;

namespace Domain.AnswerSheets
{
    public class CreatedAnswerSheetDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedAnswerSheetDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedAnswerSheetDTO(IList<string> errors)
        {
            // esta atribuição não é necessária pois isValid é false por padrão
            IsValid = false;
            Errors = errors;
        }
    }
}
