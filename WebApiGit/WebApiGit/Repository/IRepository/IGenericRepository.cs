using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGit.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> Get();

        T FindSingleBy(Expression<Func<T, bool>> predicate);

        void Create(T entity);

        void Edit(T entity);

        void Delete(T entity);

        T GetById(int id);
    }
}