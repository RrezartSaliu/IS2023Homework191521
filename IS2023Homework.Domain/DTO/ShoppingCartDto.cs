using IS2023Homework.Domain.Domain.Models;
using System.Collections.Generic;

namespace IS2023Homework.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
        public double TotalPrice { get; set; }
    }
}
