using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Models;
using BulkyWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
  
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private AppDbContext _db;
        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
      
    
       

        public void Update(Product prod)
        {
            _db.Product.Update(prod);
        }
    }
}
