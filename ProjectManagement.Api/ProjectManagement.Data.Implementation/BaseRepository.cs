using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly PMContext _context;

	public BaseRepository(PMContext dbContext)
	{
	_context = dbContext;
	}
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
