using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Model.Table
{
    public class Catetory
    {
        public Guid Id { get; set; }

        public Guid IdProducts { get; set; }

        public string Name { get; set; }

        [ForeignKey("IdProducts")]
        public ICollection<Product>? Products { get; set; }
    }
}
