using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LanguageTeacher.ConsoleApp.Interfaces;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;
using LanguageTeacher.DataAccess.Repositories;

namespace LanguageTeacher.ConsoleApp.Services.VocabularService
{
    public class VocabularService : IVocabularService
    {
        private IRepository<VerbalEntry> _repository;


        public VocabularService()
        {
            _repository = new VocabularRepository();
        }


        public ICollection<VerbalEntry> GetAll()
        {
            return _repository.GetAll();
        }

        public VerbalEntry? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(VerbalEntry item)
        {
            if (string.IsNullOrWhiteSpace(item.Foreign))
                throw new ArgumentException("Foreign word cannot be empty");

            if (item.Translations.Count == 0)
                throw new ArgumentException("Translations cannot be empty");

            var current = _repository.GetByKey(item.Foreign);

            if (current != null)
                _repository.Patch(current.Id, item);
            else
                _repository.Add(item);
        }

        public void Patch(VerbalEntry source)
        {
            var current = _repository.GetByKey(source.Foreign);

            if (current == null)
                throw new ArgumentException($"Item with foreign '{source.Foreign}' not found.");

            _repository.Patch(current.Id, source);
        }

        public void Remove(VerbalEntry item)
        {
            var current = _repository.GetByKey(item.Foreign);

            if (current == null)
                throw new ArgumentException($"Item with foreign '{item.Foreign}' not found.");

            _repository.Remove(current.Id);
        }
    }
}
