﻿using AppBooks.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppBooks.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            // Using "Update" method will update all object properties  
            //_context.Set<T>().Update(entity);

            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public T Delete(T entity)
        {
            //// Hard Delete
            //_context.Set<T>().Remove(entity);
            //_context.SaveChanges();
            //return entity;

            // Soft Delete
            _context.Set<T>().Update(entity);
            return entity;
        }

    }
}
