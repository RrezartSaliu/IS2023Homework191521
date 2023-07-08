using IS2023Homework.Domain.Domain.Models;
using IS2023Homework.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS2023Homework.Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        OrdersDTO GetOrdersForUser(string userId);
    }
}
