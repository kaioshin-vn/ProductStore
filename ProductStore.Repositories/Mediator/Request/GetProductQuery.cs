using MediatR;
using ProductStore.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.Mediator.Request
{
    public class GetProductQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
