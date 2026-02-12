using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(int id);
        TEntity? GetByKey(string key);
        ICollection<TEntity> GetAll();

        void Add(TEntity item);
        void Patch(int id, TEntity source);
        void Remove(int id);
    }
}
