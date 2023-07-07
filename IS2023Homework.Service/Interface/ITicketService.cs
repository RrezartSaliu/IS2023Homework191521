using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS2023Homework.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetDetailsForTicket (int ticketId);
        void CreateNewTicket(Ticket ticket);
        void UpdateExistingTicket(Ticket ticket);
        ShoppingCartDto GetShoppingCartInfo(int id);
        void DeleteTicket(int id);
        bool AddToShoppingCart(AddToShoppingCartDto shoppingCart, string userId);
    }
}
