using System;
using System.Collections;
using System.Collections.Generic;
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

        public VerbalEntry? Get(int id)
        {
            return _context.Pairs.Find(id);
        }

        public ICollection<VerbalEntry> GetAll()
        {
            return _context.Pairs.ToList();
        }

        public void Add(VerbalEntry verbalEntry)
        {
            var existEntry = _context.Pairs.FirstOrDefault(e => e.Foreign == verbalEntry.Foreign);

            if (existEntry is null)
            {
                _context.Add(verbalEntry);
            }
            else
            {
                existEntry.Translations.Add(verbalEntry.Translations[0]);
            }

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            VerbalEntry? verbalEntry = Get(id);

            if (verbalEntry is not null)
                _context.Remove(verbalEntry);

            _context.SaveChanges();
        }
    }
}
