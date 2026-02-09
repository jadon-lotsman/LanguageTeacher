using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace LanguageTeacher.DataAccess.Repositories
{
    public class PairsRepository : IRepository<VerbalPair>
    {
        private readonly AppDbContext _context;

        public PairsRepository()
        {
            _context = new AppDbContext();
        }

        public VerbalPair Get(int id)
        {
            return _context.Pairs.Find(id);
        }

        public ICollection<VerbalPair> GetAll()
        {
            return _context.Pairs.ToList();
        }

        public void Add(VerbalPair verbalPair)
        {
            var thatPair = _context.Pairs.FirstOrDefault(e => e.Foreign == verbalPair.Foreign);

            if (thatPair == null)
            {
                _context.Add(verbalPair);
            }
            else
            {
                thatPair.Translations.Add(verbalPair.Translations[0]);
            }

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            VerbalPair? verbalPair = _context.Pairs.FirstOrDefault(e => e.Id == id);
            
            if (verbalPair is not null)
                _context.Remove(verbalPair);

            _context.SaveChanges();
        }
    }
}
