using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Abstracts;

namespace PetsApp.REPO.Contracts
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool track = true);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
        T? GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity, bool softDelete = true);
    }
}
