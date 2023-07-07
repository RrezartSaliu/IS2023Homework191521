using IS2023Homework.Domain.Domain.Models;

namespace IS2023Homework.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Ticket SelectedTicket { get; set; }
        public int TicketId { get; set; }

        public int Quantity { get; set; }
    }
}
