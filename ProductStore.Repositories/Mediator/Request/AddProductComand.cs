using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastrucre.Mediator.Request
{
    public class AddProductComand : IRequest
    {
        public string Name { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public double Price { get; set; }
    }
}
