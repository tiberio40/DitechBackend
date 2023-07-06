using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DitechPruebaContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DitechPruebaContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll() {
            
            return _dbSet.ToList();
        }

        public TEntity Get(int id) => _dbSet.Find(id);

        public TEntity Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;


            query = query.Where(filter);

            foreach (var include in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(include.Trim());
            }


            return query.FirstOrDefault();
            //return query.FirstOrDefault(x => x.Equals(id));
        }



        public void Add(TEntity data) => _dbSet.Add(data);

       

        public void Delete(int id) { 
            var item = _dbSet.Find(id);

            _dbSet.Remove(item);
        }

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }



        public void Save() => _context.SaveChanges();

       
    }
}
