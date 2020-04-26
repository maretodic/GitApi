using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly api_testEntities context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(api_testEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public List<T> Get()
        {
            return dbSet.ToList();
        }

        public T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
    }
}