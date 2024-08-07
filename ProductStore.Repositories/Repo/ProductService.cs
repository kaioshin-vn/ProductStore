using Microsoft.EntityFrameworkCore;
using ProductStore.Infrastrucre.IRepo;
using ProductStore.Model;
using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.Repo
{
    public class ProductService : IRepo<Product>
    {
        private readonly ProductDbContext _db;
        public ProductService(ProductDbContext db) 
        {
            _db = db;
        }

        public void Add(Product product )
        {
            _db.Products.Add( product );
        }

        public Product Get(Guid id) 
        {
            Product product = null;
            if (_db.Products.Count() != 0)
            {
                 product = _db.Products.Include(a => a.Catetory).FirstOrDefault(a => a.Id == id);
            }
            return product;
        }

        public List<Product> GetList()
        {
            List<Product> listProduct = new List<Product>();
            if (_db.Products.Count() != 0)
            {
                listProduct = _db.Products.ToList();
            }
            return listProduct;
        }
    }
}
