using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.DTO;
using IS2023Homework.Repository.Implementation;
using IS2023Homework.Repository.Interface;
using IS2023Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS2023Homework.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }
        public List<Order> GetAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public OrdersDTO GetOrdersForUser(string userId)
        {
            var userOrders = this.GetAllOrders().Where(z=>z.OrderedBy.Id == userId).ToList();
            double totalSum = 0;
            foreach (var order in userOrders)
            {
                foreach (var ticket in order.Tickets) {
                    totalSum += ticket.Ticket.Price;
                }
            }
            OrdersDTO model = new OrdersDTO
            {
                Orders = userOrders
            };
            return model;

        }
    }
}
