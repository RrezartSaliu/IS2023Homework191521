using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.DTO;
using IS2023Homework.Repository.Interface;
using IS2023Homework.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IS2023Homework.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IUserRepository _userRepository;
        public readonly IRepository<ShoppingCart> _shoppingCartRepository;
        public readonly IRepository<Order> _orderRepository;
        public readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        public ShoppingCartService(IUserRepository userRepository, 
            IRepository<ShoppingCart> shoppingCartRepository, 
            IRepository<Order> orderRepository,
            IRepository<TicketInOrder> ticketInOrderRepository)
        {
            _userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
        }
        public bool deleteTicketFromShoppingCart(string userId, int ticketId)
        {
            if(!string.IsNullOrEmpty(userId) && ticketId != null)
            {
                var loggedInUser = _userRepository.GetById(userId);
                var userShoppingCart = loggedInUser.UserShoppingCart;
                var itemToDelete = userShoppingCart.TicketsInShoppingCart.Where(z=> z.TicketId == ticketId).FirstOrDefault();
                userShoppingCart.TicketsInShoppingCart.Remove(itemToDelete);
                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ShoppingCartDto GetShoppingCartInfo(string userId)
        {
            var user = _userRepository.GetById(userId);

            var userShoppingCart = user.UserShoppingCart;

            var ticketList = userShoppingCart.TicketsInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                Price = z.Ticket.Price
            });
            double totalPrice = 0;
            foreach (var item in ticketList)
            {
                totalPrice += item.Price * item.Quantity;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCart.TicketsInShoppingCart.ToList()
            };
            return model;
        }

        public bool orderNow(string userId)
        {
            var user = _userRepository.GetById(userId);
            var userShoppingCart = user.UserShoppingCart;
            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };
            _orderRepository.Insert(newOrder);
            List<TicketInOrder> ticketInOrder = userShoppingCart.TicketsInShoppingCart.Select(z => new TicketInOrder
            {
                Ticket = z.Ticket,
                TicketId = z.TicketId,
                Order = newOrder,
                OrderId = newOrder.Id
            }).ToList();
            foreach (var ticket in ticketInOrder)
            {
                _ticketInOrderRepository.Insert(ticket);
            }
            user.UserShoppingCart.TicketsInShoppingCart.Clear();
            _userRepository.Update(user);
            return true;
        }
    }
}
