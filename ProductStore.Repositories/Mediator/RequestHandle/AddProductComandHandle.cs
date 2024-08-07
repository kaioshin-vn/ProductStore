using MediatR;
using ProductStore.Infrastrucre.Mediator.Request;
using ProductStore.Infrastrucre.UnitOfWork;
using ProductStore.Model;
using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.Mediator.RequestHandle
{
    public class AddProductComandHandle : IRequestHandler<AddProductComand>
    {
        private readonly ProductDbContext _db;
        public AddProductComandHandle(ProductDbContext db) {
            _db = db;
        }
        public async Task Handle(AddProductComand request, CancellationToken cancellationToken)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(_db);
            if (!unitOfWork.CategoryService.CheckExist(request.Category))
            {
                var cate = new Catetory();
                cate.Name = request.Category;
                unitOfWork.CategoryService.Add(cate);
            }
            var product = new Product();
            product.Name = request.Name;
            product.Amount = request.Amount;
            product.Price = request.Price;
            product.Description = request.Description;


            unitOfWork.ProductService.Add(product);

            unitOfWork.Excute();
        }

    }
}
