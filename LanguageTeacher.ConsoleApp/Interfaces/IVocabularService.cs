using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;

namespace LanguageTeacher.ConsoleApp.Interfaces
{
    public interface IVocabularService
    {
        VerbalEntry? GetById(int id);
        ICollection<VerbalEntry> GetAll();
        void Add(VerbalEntry item);
        void Patch(VerbalEntry source);
        void Remove(VerbalEntry item);
    }
}
