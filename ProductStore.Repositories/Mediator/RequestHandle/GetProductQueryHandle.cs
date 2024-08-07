using MediatR;
using ProductStore.Infrastrucre.Mediator.Request;
using ProductStore.Infrastrucre.Repo;
using ProductStore.Model;
using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.Mediator.RequestHandle
{
    public class GetProductQueryHandle : IRequestHandler<GetProductQuery, Product>
    {
        private readonly ProductDbContext _db;
        public GetProductQueryHandle(ProductDbContext db)
        {
            _db = db;
        }
        public Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var productSer = new ProductService(_db);
            var product = productSer.Get(request.Id);
            return Task.FromResult(product);
        }
    }
}
