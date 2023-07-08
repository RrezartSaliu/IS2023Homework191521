using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.DTO;
using IS2023Homework.Repository.Interface;
using IS2023Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS2023Homework.Service.Implementation
{
    public class TicketService : ITicketService
    {
        public readonly IRepository<Ticket> _ticketRepository;
        public readonly IUserRepository _userRepository;
        public readonly IRepository<TicketsInShoppingCart> _ticketsInShoppingCartRepository;
        public TicketService(IRepository<Ticket> ticketRepository, IUserRepository userRepository, IRepository<TicketsInShoppingCart> ticketsInShoppingCartRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _ticketsInShoppingCartRepository = ticketsInShoppingCartRepository;
        }

        public bool AddToShoppingCart(AddToShoppingCartDto shoppingCart, string userId)
        {
            var user = _userRepository.GetById(userId);
            var userShoppingCart = user.UserShoppingCart;
            if (userShoppingCart != null)
            {
                var ticket = this.GetDetailsForTicket(shoppingCart.TicketId);
                if (ticket != null)
                {
                    TicketsInShoppingCart itemToAdd = new TicketsInShoppingCart
                    {
                        Ticket = ticket,
                        TicketId = ticket.Id,
                        ShoppingCart = userShoppingCart,
                        CartId = userShoppingCart.Id,
                        Quantity = shoppingCart.Quantity
                    };
                    _ticketsInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
            }
            return false;
        }

        public void CreateNewTicket(Ticket ticket)
        {
            this._ticketRepository.Insert(ticket);
        }

        public void DeleteTicket(int id)
        {
            var ticket = _ticketRepository.Get(id);
            this._ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(int ticketId)
        {
            return _ticketRepository.Get(ticketId);
        }

        public ShoppingCartDto GetShoppingCartInfo(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingTicket(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }
    }
}
