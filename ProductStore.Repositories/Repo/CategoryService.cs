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
    public class CategoryService : IRepo<Catetory>
    {
        private readonly ProductDbContext _db;
        public CategoryService(ProductDbContext db)
        {
            _db = db;
        }
        public void Add(Catetory catetory)
        {
            _db.Categories.Add(catetory);
        }

        public bool CheckExist(string name)
        {
            if (_db.Categories.Count() != 0)
            {
                return _db.Categories.Any(a => a.Name == name);
            }
            return false;
        }
    }
}
