﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> FindAsync(int id);
        Task<T> FindAsync(decimal id);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync<K>(Expression<Func<T, IEnumerable<K>>> selectExpression);
        Task<int> CountAsync<K>(Expression<Func<T, bool>> expression, Expression<Func<T, IEnumerable<K>>> selectExpression);
        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> ListPaginationAsync<K>(Expression<Func<T, K>> sortExpression, int pagina, int quantidade);
        Task<List<T>> ListPaginationAsync<K>(Expression<Func<T, bool>> expression, Expression<Func<T, K>> sortExpression, int pagina, int quantidade);
        Task<T> AddAsync(T item);
        Task RemoveAsync(T item);
        Task<T> EditAsync(T item);

    }
}
