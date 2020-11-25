﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TechnoStore.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Order = new List<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
