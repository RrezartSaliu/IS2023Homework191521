using IS2023Homework.Domain.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IS2023Homework.Domain.Domain.Models
{
	public class Order : BaseEntity
	{
		public string UserId { get; set; }
		public ShopApplicationUser OrderedBy { get; set; }
		public List<TicketInOrder> Tickets { get; set; }
	}
}
