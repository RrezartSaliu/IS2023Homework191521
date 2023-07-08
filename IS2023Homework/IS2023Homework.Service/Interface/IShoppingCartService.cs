using IS2023Homework.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS2023Homework.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetShoppingCartInfo(string userId);
        bool deleteTicketFromShoppingCart(string userId, int ticketId);
        bool orderNow(string userId);
    }
}
