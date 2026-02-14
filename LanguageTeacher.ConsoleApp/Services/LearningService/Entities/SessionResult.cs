using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using static System.Collections.Specialized.BitVector32;

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
                var entry = service.GetById(question.EntryId);
                string[] transcriptions = entry.Translations.ToArray();

                if (transcriptions.Contains(question.UserAnswer))
                {
                    CorrectAnswersCount++;
                }
            }
        }

        public override string ToString()
        {
            return $"{CorrectAnswersCount}/{TotalAnswerCount}";
        }
    }
}
