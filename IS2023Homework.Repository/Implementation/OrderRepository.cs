using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS2023Homework.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;
        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.Tickets).Include("Tickets.Ticket").ToList();
        }

        public Order getOrderDetails(BaseEntity entity)
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.Tickets).Include("Tickets.Ticket").SingleOrDefault(z=>z.Id==entity.Id);
        }
    }
}
