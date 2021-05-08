using ConferenceWebApp.Data;
using ConferenceWebApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceWebApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
        // dependency injection - inject the class here
        public Repository(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            // asnotracking added not to receive notifications every time we change something
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            return RepositoryContext.Set<T>().Update(entity).Entity;
        }
    }
}
