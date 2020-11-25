using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoStore.Models
{
    public partial class Category
    {

        public Category()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string CategoryPicUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
