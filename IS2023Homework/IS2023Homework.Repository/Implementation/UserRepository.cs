using IS2023Homework.Domain.Identity;
using IS2023Homework.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS2023Homework.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShopApplicationUser> entities;
        string errorMessage = string.Empty;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShopApplicationUser>();
        }
        public void Delete(ShopApplicationUser user)
        {
            if(user == null) { throw new ArgumentNullException("user"); }
            entities.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<ShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ShopApplicationUser GetById(string id)
        {
            return entities.Include(z=>z.UserShoppingCart).
                Include("UserShoppingCart.TicketsInShoppingCart").
                Include("UserShoppingCart.TicketsInShoppingCart.Ticket").SingleOrDefault(x=>x.Id == id);
        }

        public void Insert(ShopApplicationUser user)
        {
            if (user == null) { throw new ArgumentNullException("user"); }
            entities.Add(user);
            context.SaveChanges();
        }

        public void Update(ShopApplicationUser user)
        {
            if (user == null) { throw new ArgumentNullException("user"); }
            entities.Update(user);
            context.SaveChanges();
        }
    }
}
