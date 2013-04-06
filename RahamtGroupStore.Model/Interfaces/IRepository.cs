using System;
using System.Linq;
using System.Linq.Expressions;

namespace RahamtGroupStore.Model.Interfaces
{
    internal interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        T FindById(Int64 id);
        bool IsEntityExists(Expression<Func<T,bool>>  expression);
        IQueryable<T> Search(Expression<Func<T, bool>> expression);
    }
}