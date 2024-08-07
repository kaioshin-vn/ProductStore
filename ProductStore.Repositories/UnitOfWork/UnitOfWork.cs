using ProductStore.Infrastrucre.Interface;
using ProductStore.Infrastrucre.IRepo;
using ProductStore.Infrastrucre.Repo;
using ProductStore.Model;
using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _db;

        private ProductService productService;
        private CategoryService categoryService;
        public UnitOfWork (ProductDbContext db)
        {
            _db = db;
        }


        public ProductService ProductService { get {
                if (productService == null)
                {
                    this.productService = new ProductService(_db);
                }

                return this.productService;
            } }
        public CategoryService CategoryService
        {
            get
            {
                if (categoryService == null)
                {
                    this.categoryService = new CategoryService(_db);
                }

                return this.categoryService;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Excute()
        {
            _db.SaveChanges();
        }
    }
}
