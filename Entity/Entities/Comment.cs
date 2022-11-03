using Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Comment : BaseEntity
    {
        public ICollection<Product> Products { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime WriteDate { get; set; }
    }
}
