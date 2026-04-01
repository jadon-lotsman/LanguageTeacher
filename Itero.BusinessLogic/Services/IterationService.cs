using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itero.DataAccess.Data;
using Itero.DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itero.BusinessLogic.Services
{
    public class IterationService
    {
        private AppDbContext _context;
        private VocabularyService _vocabularyService;
        private UserService _userService;

        public IterationService(AppDbContext context, UserService userService, VocabularyService vocabularyService)
        {
            _context = context;
            _userService = userService;
            _vocabularyService = vocabularyService;
        }


        public Iteration? GetIteration(int userId)
        {
            return _context.Iterations.FirstOrDefault(e => e.User.Id == userId);
        }

        public IterationPart? GetIterationQuestionById(int userId, int id)
        {
            return _context.IterationQuestions.FirstOrDefault(q => q.Id == id && q.Iteration.UserId == userId);
        }

        public Iteration? Create(int userId)
        {
            var myIteration = GetIteration(userId);

            if (myIteration == null)
            {
                User owner = _userService.GetById(userId);
                var questions = new List<IterationPart>();

                var rendomEntries = _vocabularyService.GetRandom(userId);

                foreach (var entry in rendomEntries)
                {
                    IterationPart question = new IterationPart(entry, true);

                    questions.Add(question);
                }

                myIteration = new Iteration(owner, questions);

                _context.Iterations.Add(myIteration);
                _context.SaveChanges();

                return myIteration;
            }

            return null;
        }


        public bool SetValue(int userId, int id)
        {
            // TODO: Установить ответ IterationPart
            return true;
        }

        public bool GetResult(int userId)
        {
            // TODO: Сформировать IterationResult и вернуть его
            return true;
        }
    }
}
