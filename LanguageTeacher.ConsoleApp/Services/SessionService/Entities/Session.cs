using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;

namespace LanguageTeacher.ConsoleApp.Services.SessionService.Entities
{
    public class Session
    {
        public Question[] Questions { get; }

        private int _currentIndex;


        public Session(IVocabularService service, ISessionStrategy strategy)
        {
            var entries = service.GetAll();
            Questions = strategy.SelectQuestions(entries).ToArray();

            _currentIndex = 0;
        }


        public void SetAnswer(int index, string value)
        {
            Questions[index].UserValue = value;
        }

        public void NextQuestion(string answer)
        {
            SetAnswer(_currentIndex, answer);
            _currentIndex++;
        }
    }
}
