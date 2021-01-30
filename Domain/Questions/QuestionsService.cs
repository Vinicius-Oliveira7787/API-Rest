﻿using System;

namespace Domain.Questions
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsService(IQuestionsRepository repository)
        {
            _questionsRepository = repository;
        }
        public CreatedQuestionDTO Create(Guid answerSheetId, string name)
        {
            var question = new Question(answerSheetId, name);
            var questionValidation = question.Validate();

            if (questionValidation.isValid)
            {
                _questionsRepository.Add(question);
                return new CreatedQuestionDTO(question.Id);
            }

            return new CreatedQuestionDTO(questionValidation.errors);
        }
    }
}
