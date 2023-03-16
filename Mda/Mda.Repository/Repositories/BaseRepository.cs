using Mda.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Repository.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class 
        // As classes abstratas são as que não permitem realizar qualquer tipo de instância.
    {
        public Task<T> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync<K>(Expression<Func<T, IEnumerable<K>>> selectExpression)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync<K>(Expression<Func<T, bool>> expression, Expression<Func<T, IEnumerable<K>>> selectExpression)
        {
            throw new NotImplementedException();
        }

        public Task<T> EditAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(decimal id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListPaginationAsync<K>(Expression<Func<T, K>> sortExpression, int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListPaginationAsync<K>(Expression<Func<T, bool>> expression, Expression<Func<T, K>> sortExpression, int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
