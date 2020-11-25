using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoStore.Models
{
    public class Order
    {
        public Order()
        {
            Products = new List<ProductOrder>();
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int PostalCode { get; set; }

        public ICollection<ProductOrder> Products { get; set; }

    }
}
