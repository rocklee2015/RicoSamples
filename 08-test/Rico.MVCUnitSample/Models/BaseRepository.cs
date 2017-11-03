using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rico.MVCUnitSample.Models
{
    public abstract class BaseRepository<C, T> : IBaseRepository<T> where T : class where C : DbContext, new()
    {
        private C _db = new C();

        public C Db
        {
            get { return _db; }
            set { _db = value; }
        }

        public System.Linq.IQueryable<T> GetAll()
        {
            IQueryable<T> query = _db.Set<T>();
            return query;
        }

        public System.Linq.IQueryable<T> FindBy(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            IQueryable<T> query = _db.Set<T>().Where(predicate);
            return query;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Edit(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }

}