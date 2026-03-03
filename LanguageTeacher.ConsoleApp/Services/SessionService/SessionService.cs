using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.ConsoleApp.Services.SessionService.Entities;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Services.SessionService
{
    public class SessionService : IStudySessionService
    {
        private IVocabularService _vocabularService;
        private Session? _session;


        public SessionService(IVocabularService vocabularService)
        {
            _vocabularService = vocabularService;
        }


        public bool HasOpenSession()
        {
            return _session != null;
        }

        public ICollection<Question> GetQuestions()
        {
            if (_session == null)
                throw new ArgumentException("Learning session is null.");

            return _session.Questions;
        }

        public void OpenSession(ISessionStrategy strategy)
        {
            var entries = _vocabularService.GetAll();
            var questions = strategy.SelectQuestions(entries);

            _session = new Session(_vocabularService, strategy);
        }

        public SessionResult CloseSession()
        {
            if (_session == null)
                throw new ArgumentException("An session to close is not found.");

            SessionResult result = new SessionRevisor().Review(_session, _vocabularService);
            _session = null;

            return result;
        }

        public void SendAnswer(string answer)
        {
            if (_session == null)
                throw new ArgumentException("Learning session is null.");

            _session.NextQuestion(answer);
        }
    }
}
