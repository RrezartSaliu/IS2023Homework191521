using System.ComponentModel.DataAnnotations.Schema;

namespace IS2023Homework.Domain.Domain.Models
{
    public class TicketsInShoppingCart : BaseEntity
    {
        public int TicketId { get; set; }
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }  
        public int Quantity { get; set; }
    }
}
