using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PetsApp.CORE.Abstracts;
using PetsApp.CORE.Enums;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.Contracts;

namespace PetsApp.REPO.Concretes
{

    public abstract class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly PetsAppDbContext _context;
        private DbSet<T> _dbSet;
        protected BaseRepo(PetsAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Create(T entity) => _context.Add(entity);
        public void Delete(T entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.DeletedAt = DateTime.Now;
                entity.Status = Status.Deleted;
                _context.Update(entity);
            }
            else
            {
                _context.Remove(entity);
            }
        }
        public IQueryable<T> GetAll(bool track = true) => track ? _dbSet : _dbSet.AsNoTracking();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition) => _dbSet.Where(condition);
        public T? GetById(int id) => _dbSet.Find(id);
        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.Status = Status.Updated;
            _dbSet.Update(entity);
        }
    }
}
