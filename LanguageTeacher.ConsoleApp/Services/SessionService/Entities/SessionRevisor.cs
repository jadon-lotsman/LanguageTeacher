using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Services.SessionService.Entities
{
    public class SessionRevisor
    {
        public SessionResult Review(Session session, IVocabularService service)
        {
            int correctCount = 0;
            int totalCount = session.Questions.Length;
            var failedEntites = new List<VerbalEntry>();

            const float SimilarityBorder = 0.75f;

            foreach (Question question in session.Questions)
            {
                var currentEntry = service.GetById(question.EntryId);
                float similarity = ToCorrectSimilarity(question, currentEntry);

                if (similarity >= SimilarityBorder)
                {
                    correctCount++;
                }
                else
                {
                    failedEntites.Add(currentEntry);
                }
            }

            return new SessionResult(correctCount, totalCount, failedEntites.ToArray());
        }

        private float ToCorrectSimilarity(Question question, VerbalEntry sourceEntry)
        {
            string userValue = question.UserValue;
            float maxSimilarity = 0;

            if (question.IsForwardQuestion)
            {
                foreach (string translation in sourceEntry.Translations)
                {
                    float currentSimilarity = userValue.GetSimilarity(translation);
                    maxSimilarity = Math.Max(maxSimilarity, currentSimilarity);
                }

                return maxSimilarity;
            }
            else
                return userValue.GetSimilarity(sourceEntry.Foreign);
        }
    }
}
