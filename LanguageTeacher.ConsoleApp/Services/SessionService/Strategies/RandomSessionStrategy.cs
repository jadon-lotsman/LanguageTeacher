using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.ConsoleApp.Services.SessionService.Entities;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Services.SessionService.Strategies
{
    public class RandomSessionStrategy : ISessionStrategy
    {
        private static Random _random = new Random();

        public List<Question> SelectQuestions(ICollection<VerbalEntry> entries)
        {
            VerbalEntry[] entriesArray = entries.ToArray();
            _random.Shuffle(entriesArray);

            List<Question> questions = new List<Question>();

            for (int i = 0; i < 8; i++)
            {
                Question question = new Question(entriesArray[i], _random.Next(2) == 1);

                questions.Add(question);
            }

            return questions;
        }
    }
}
