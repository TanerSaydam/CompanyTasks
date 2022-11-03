using Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
