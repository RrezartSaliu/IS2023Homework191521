using IS2023Homework.Domain.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS2023Homework.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity entity);
    }
}
