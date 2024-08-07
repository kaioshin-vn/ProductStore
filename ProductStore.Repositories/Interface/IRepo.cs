using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.IRepo
{
    public interface IRepo<T> where T : class
    {
        public void Add(T product);
    }
}
