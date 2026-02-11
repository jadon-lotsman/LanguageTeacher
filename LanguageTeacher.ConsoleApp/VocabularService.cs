using System;
using System.Collections.Generic;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;
using LanguageTeacher.DataAccess.Repositories;

namespace LanguageTeacher.ConsoleApp
{
    public class VocabularService
    {
        private IRepository<VerbalEntry> _repository;

        public VocabularService()
        {
            _repository = new VocabularRepository();
        }

        public List<VerbalEntry> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Add(VerbalEntry entry)
        {
            if (string.IsNullOrWhiteSpace(entry.Foreign))
                throw new ArgumentException("Foreign word cannot be empty", nameof(entry.Foreign));

            if (entry.Translations.Count == 0)
                throw new ArgumentException("Translation word cannot be empty", nameof(entry.Translations));

            _repository.Add(entry);
        }

        public void Remove(int id)
        {
            if (_repository.Get(id) ==  null)
                throw new ArgumentException("That item is null");

            _repository.Remove(id);
        }
    }
}
