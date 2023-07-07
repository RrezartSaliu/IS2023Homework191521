using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IS2023Homework.Domain.Domain.Models
{
    public class ShoppingCart : BaseEntity
    {

        public string ApplicationUserId { get; set; }
        public ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
    }
}
