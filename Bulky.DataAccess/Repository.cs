using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet; // As We know it is Generic Repository do we have to Create Internal Dbset
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>(); // Whatever Entity will be it will use that Entity which needed not Specifically to One Entity
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query=query.Where(filter);
            var result = query.FirstOrDefault();

            if (result == null)
            {
                throw new InvalidOperationException("No elements found in the query.");
            }
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
