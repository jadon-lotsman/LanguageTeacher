using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Itero.BusinessLogic.DTOs;
using Itero.DataAccess.Data;
using Itero.DataAccess.Data.Entities;

namespace Itero.BusinessLogic.Services
{
    public class VocabularyService
    {
        private AppDbContext _context;
        private UserService _userService;


        public VocabularyService(AppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }


        public ICollection<VocabularyEntry> GetAll(int userId)
        {
            return _context.Entries.Where(e => e.User.Id == userId).ToList();
        }

        public ICollection<VocabularyEntry> GetRandom(int userId, int takeNumber=5)
        {
            var randomEntries = GetAll(userId)
                .OrderBy(x => Guid.NewGuid())
                .Take(takeNumber)
                .ToList();

            return randomEntries;
        }

        public VocabularyEntry? GetById(int userId, int id)
        {
            return _context.Entries.FirstOrDefault(e => e.Id == id && e.UserId == userId);
        }

        public VocabularyEntry? Create(int userId, VocabularCreateDTO dto)
        {
            var current = _context.Entries.FirstOrDefault(e => e.Foreign == dto.Foreign && e.UserId == userId);

            if (current == null)
            {
                var entry = new VocabularyEntry();
                entry.Foreign = dto.Foreign;

                foreach (var translation in dto.Translations)
                    entry.Translations.Add(translation);

                entry.User = _userService.GetById(userId);
                _context.Entries.Add(entry);

                _context.SaveChanges();

                return entry;
            }

            return null;
        }

        public VocabularyEntry? Update(int userId, int id, VocabularUpdateDTO dto)
        {
            var current = GetById(userId, id);

            if (current != null)
            {
                if (dto.Foreign != null)
                    current.Foreign = dto.Foreign;

                if (dto.Transcription != null)
                    current.Transcription = dto.Transcription;

                if (dto.ExamplesAdd != null)
                    foreach (var example in dto.ExamplesAdd)
                        current.Examples.Add(example);

                if (dto.ExamplesDelete != null)
                    foreach (var example in dto.ExamplesDelete)
                        current.Examples.Remove(example);

                if (dto.TranslationsAdd != null)
                    foreach (var example in dto.TranslationsAdd)
                        current.Translations.Add(example);

                if (dto.TranslationsDelete != null)
                    foreach (var example in dto.TranslationsDelete)
                        current.Translations.Remove(example);

                _context.SaveChanges();

                return current;
            }

            return null;
        }

        public bool Remove(int userId, int id)
        {
            var current = GetById(userId, id);

            if (current != null)
            {
                _context.Remove(current);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
