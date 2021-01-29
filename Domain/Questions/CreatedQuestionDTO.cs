using System;
using System.Collections.Generic;

namespace Domain.Questions
{
    public class CreatedQuestionDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedQuestionDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedQuestionDTO(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
