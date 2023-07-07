using IS2023Homework.Domain.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IS2023Homework.Domain.Identity
{
    public class ShopApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserShoppingCart { get; set; }
    }
}
