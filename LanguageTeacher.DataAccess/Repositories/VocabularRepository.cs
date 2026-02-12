using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace LanguageTeacher.DataAccess.Repositories
{
    public class VocabularRepository : IRepository<VerbalEntry>
    {
        private readonly AppDbContext _context;

        public VocabularRepository()
        {
            _context = new AppDbContext();
        }

        public VerbalEntry? GetById(int id)
        {
            return _context.Pairs.Find(id);
        }

        public VerbalEntry? GetByKey(string key)
        {
            return _context.Pairs.FirstOrDefault(e => e.Foreign == key);
        }

        public ICollection<VerbalEntry> GetAll()
        {
            return _context.Pairs.ToList();
        }

        public void Add(VerbalEntry item)
        {
            var currentEntry = GetByKey(item.Foreign);

            if (currentEntry is null)
            {
                _context.Add(item);
            }
            else
                new ArgumentException("VerbalEntry is exist");

            _context.SaveChanges();
        }

        public void Patch(int id, VerbalEntry source)
        {
            var currentEntry = GetById(id);

            if (source.Foreign is not null)
                currentEntry.Foreign = source.Foreign;

            if (source.Translations.Count != 0)
                currentEntry.Translations.AddRange(source.Translations);

            if (source.Transcription is not null)
                currentEntry.Transcription = source.Transcription;

            if (source.Examples.Count != 0)
                currentEntry.Examples.AddRange(source.Examples);

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            VerbalEntry? verbalEntry = GetById(id);

            if (verbalEntry is not null)
                _context.Remove(verbalEntry);

            _context.SaveChanges();
        }
    }
}
