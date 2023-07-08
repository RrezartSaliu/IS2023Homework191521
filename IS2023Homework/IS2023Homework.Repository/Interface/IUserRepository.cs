using IS2023Homework.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS2023Homework.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ShopApplicationUser> GetAll();
        ShopApplicationUser GetById(string id);
        void Insert(ShopApplicationUser user);
        void Update(ShopApplicationUser user);
        void Delete(ShopApplicationUser user);
    }
}
