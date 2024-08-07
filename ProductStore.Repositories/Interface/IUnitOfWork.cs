using System;
using System.Collections.Generic;
using System.Linq; 

using System.Text;
using System.Threading.Tasks;
using ProductStore.Infrastrucre.Repo;
using ProductStore.Model.Table;

namespace ProductStore.Infrastrucre.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ProductService ProductService { get; }
        CategoryService CategoryService { get; }

        void Excute();
    }
}
    