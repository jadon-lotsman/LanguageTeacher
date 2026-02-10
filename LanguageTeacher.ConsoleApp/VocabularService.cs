using System;
using System.Collections.Generic;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;

namespace LanguageTeacher.ConsoleApp
{
    public class VocabularService
    {
        private IRepository<VerbalEntry> _repository;

        public VocabularService(IRepository<VerbalEntry> repository)
        {
            _repository = repository;
        }

        public List<VerbalEntry> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Add(string foreign, string translate)
        {
            if (string.IsNullOrWhiteSpace(foreign))
                throw new ArgumentException("Foreign word cannot be empty", nameof(foreign));

            if (string.IsNullOrWhiteSpace(translate))
                throw new ArgumentException("Translation word cannot be empty", nameof(translate));

            foreign = foreign.ToLower().RemoveMultispaces();
            translate = translate.ToLower().RemoveMultispaces();

            VerbalEntry pair = new VerbalEntry()
            {
                Foreign = foreign,
                Translations = { translate }
            };

            _repository.Add(pair);
        }

        public void Remove(int id)
        {
            if (_repository.Get(id) ==  null)
                throw new ArgumentException("That item is null");

            _repository.Remove(id);
        }
    }
}
