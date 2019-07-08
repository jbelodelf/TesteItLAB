﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Teste.ItLAB.Model.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Select(params string[] includes);
        IQueryable<T> Select(Expression<Func<T, bool>> expression, params string[] includes);
        void Insert(T entity);
        void Insert(IEnumerable<T> entity);
        void Update(T entity);
        T Update(T entity, params string[] fieldsToUpdate);
        T Update(T entity, bool cascade = false);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        void Dispose();
    }
}
