using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;

namespace LanguageTeacher.ConsoleApp
{
    public class VocabularService
    {
        private IRepository<VerbalPair> _repository;

        public VocabularService(IRepository<VerbalPair> repository)
        {
            _repository = repository;
        }

        public List<VerbalPair> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Add(string foreign, string translate)
        {
            foreign = foreign.ToLower().RemoveMultispaces();
            translate = translate.ToLower().RemoveMultispaces();

            VerbalPair pair = new VerbalPair()
            {
                Foreign = foreign,
                Translations = { translate }
            };

            _repository.Add(pair);
        }
    }
}
