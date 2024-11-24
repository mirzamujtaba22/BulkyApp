using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _context = db;
            CategoryRepository = new CategoryRepository(_context);
        }
      

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
