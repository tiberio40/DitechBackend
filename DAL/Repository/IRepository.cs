using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<TEntity>
    {
        public IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");

        void Add(TEntity data);

        void Delete(int id);

        void Update(TEntity data);

        void Save();

    }
}
