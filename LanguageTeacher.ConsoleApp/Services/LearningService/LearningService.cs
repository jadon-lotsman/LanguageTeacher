using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.ConsoleApp.Services.StudyService.Entities;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Services.StudyService
{
    public class LearningService : ILearningService
    {
        private IVocabularService _vocabularService;
        private LearningSession session;

        public LearningService(IVocabularService vocabularService)
        {
            _vocabularService = vocabularService;
        }

        public bool IsComplete()
        {
            if (session == null)
                return true;

            return session.IsEnd;
        }

        public ICollection<VerbalQuestion> GetAll()
        {
            return session.Questions;
        }

        public void StartSession()
        {
            session = new LearningSession(new QuestionGenerator().Generate(_vocabularService.GetAll()));
        }

        public SessionResult StopSession()
        {
            return session.StopAndGetResult(_vocabularService);
        }

        public void GetAnswer(string answer)
        {
            session.NextQuestion(answer);
        }
    }

    public class QuestionGenerator
    {
        public VerbalQuestion[] Generate(ICollection<VerbalEntry> verbals)
        {
            List<VerbalQuestion> parts = new List<VerbalQuestion>();

            foreach (VerbalEntry verbal in verbals)
            {
                parts.Add(new VerbalQuestion(verbal.Id, verbal.Foreign));
            }

            return parts.ToArray();
        }
    }
}
