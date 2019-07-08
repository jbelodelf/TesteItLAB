﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Teste.ItLAB.Model.Interfaces.Base;

namespace Teste.ItLAB.Data.Repositories.Base
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private readonly DbContextOptionsBuilder<ContextAplication> _OptionsBuider;
        private readonly ContextAplication _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(ContextAplication context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }

        public void Delete(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            _context.Set<T>().RemoveRange(_context.Set<T>().Where(expression));
            _context.SaveChanges();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Insert(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> Select(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes.Any())
            {
                if (expression != null)
                {
                    query = includes.Aggregate(query.Where(expression), (current, include) => current.Include(include));
                }
                else
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }
            }
            else
            {
                if (expression != null)
                {
                    query = query.Where(expression);
                }
            }

            return query;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public T Update(T entity, params string[] fieldsToUpdate)
        {
            _context.Entry(entity).State = EntityState.Modified;

            Type tipo = entity.GetType();
            IList<string> listFieldsToUpdate = fieldsToUpdate.ToList();

            foreach (PropertyInfo prop in tipo.GetProperties())
            {
                if (listFieldsToUpdate.Any(p => p == prop.Name))
                {
                    _context.Entry(entity).Property(prop.Name).IsModified = true;
                    listFieldsToUpdate.Remove(prop.Name);
                    continue;
                }

                if (!prop.CustomAttributes.Any(c => c.AttributeType.Name == "KeyAttribute") &&
                    !prop.CustomAttributes.Any(c => c.AttributeType.Name == "NotMappedAttribute") &&
                    prop.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) == null)
                {
                    _context.Entry(entity).Property(prop.Name).IsModified = false;
                }
            }

            _context.SaveChanges();

            return entity;
        }

        public T Update(T entity, bool cascade = false)
        {
            _context.Entry(entity).State = EntityState.Modified;

            if (cascade)
            {
                foreach (var item in typeof(T).GetProperties())
                {
                    var a = item.GetValue(entity);
                    if (item.PropertyType.IsClass && Attribute.IsDefined(item.PropertyType, typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute)) && a != null)
                    {
                        Type tipo = Assembly.GetAssembly(item.PropertyType).GetType(item.PropertyType.FullName);
                        _context.Entry(a).State = EntityState.Modified;
                    }
                }
            }

            _context.SaveChanges();

            return entity;
        }

        #region Disposable
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_context != null) _context.Dispose();
                }
                _disposed = true;
            }
        }
        #endregion
    }
}
