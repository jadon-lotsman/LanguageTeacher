using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        ICollection<T> GetAll();

        void Add(T item);
        void Remove(int id);
    }
}
