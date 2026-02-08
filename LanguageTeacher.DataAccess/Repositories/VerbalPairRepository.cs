using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data;
using LanguageTeacher.DataAccess.Data.Entities;
using LanguageTeacher.DataAccess.Interfaces;


namespace LanguageTeacher.DataAccess.Repositories
{
    public class VerbalPairRepository : IRepository<VerbalPair>
    {
        private readonly VocabularAppContext _context;

        public VerbalPairRepository(VocabularAppContext context)
        {
            _context = context;
        }

        public VerbalPair Get(int id)
        {
            return _context.VerbalPairs.First(e => e.Id == id);
        }

        public ICollection<VerbalPair> GetAll()
        {
            return _context.VerbalPairs.ToList();
        }

        public void Add(VerbalPair verbalPair)
        {
            _context.Add(verbalPair);

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            VerbalPair? verbalPair = _context.VerbalPairs.FirstOrDefault(e => e.Id == id);
            
            if (verbalPair is not null)
                _context.Remove(verbalPair);

            _context.SaveChanges();
        }
    }
}
