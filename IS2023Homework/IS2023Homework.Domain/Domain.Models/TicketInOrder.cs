using System.ComponentModel.DataAnnotations.Schema;

namespace IS2023Homework.Domain.Domain.Models
{
	public class TicketInOrder : BaseEntity
	{
		[ForeignKey("TicketId")]
		public int TicketId { get; set; }
		[ForeignKey("OrderId")]
		public int OrderId { get; set; }
		public Ticket Ticket { get; set; }
		public Order Order { get; set; }
	}
}
