using System;
using System.Collections.Generic;

namespace Domain.Answers
{
    public class CreatedAnswerDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedAnswerDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedAnswerDTO(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
