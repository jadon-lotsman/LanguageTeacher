using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;

namespace LanguageTeacher.ConsoleApp.Services.StudyService.Entities
{
    public class LearningSession
    {
        public VerbalQuestion[] Questions { get; }
        public bool IsEnd = false;

        private int _currentQuestion;


        public LearningSession(VerbalQuestion[] questions)
        {
            Questions = questions;
            _currentQuestion = 0;
        }


        public void NextQuestion(string answer)
        {
            Questions[_currentQuestion].UserAnswer = answer;
            _currentQuestion++;
        }

        public SessionResult StopAndGetResult(IVocabularService service)
        {
            IsEnd = true;
            return new SessionResult(this, service);
        }
    }
}
