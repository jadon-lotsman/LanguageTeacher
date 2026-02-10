using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacher.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        ICollection<TEntity> GetAll();

        void Add(TEntity item);
        void Remove(int id);
    }
}
