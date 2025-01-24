using ElevenEleven.Data;
using ElevenEleven.Repository.IRepository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElevenEleven.Repository
{
    public class BaseRepository<T>(ApplicationDbContext _context) : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext DbContext =_context;

        public T GetById(object id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).ToList();
        }

        public void Insert(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }

        public int Save()
        {
            return DbContext.SaveChanges();
        }
    }
}
