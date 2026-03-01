using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Services.StudyService.Entities
{
    public class SessionResult
    {
        public int CorrectAnswersCount { get; }
        public int TotalAnswerCount { get; }


        public SessionResult(LearningSession session, IVocabularService service)
        {
            TotalAnswerCount = session.Questions.Length;

            foreach (var question in session.Questions)
            {
                var sourceEntry = service.GetById(question.EntryId);

                if (IsCorrectQuestion(question, sourceEntry))
                    CorrectAnswersCount++;
            }
        }


        private bool IsCorrectQuestion(Question question, VerbalEntry sourceEntry)
        {
            var sourceTranslations = sourceEntry.Translations.ToArray();

            if (question.IsForwardQuestion)
                return sourceTranslations.Contains(question.UserValue);
            else
                return question.UserValue == sourceEntry.Foreign;
        }

        public override string ToString()
        {
            return $"{CorrectAnswersCount}/{TotalAnswerCount}";
        }
    }
}
