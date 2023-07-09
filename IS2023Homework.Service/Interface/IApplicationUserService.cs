using IS2023Homework.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS2023Homework.Service.Interface
{
    public interface IApplicationUserService
    {
        List<ShopApplicationUser> GetAll();
        ShopApplicationUser Get(string id);
        void Update(string  id, string role);
        void Insert(ShopApplicationUser user);
    }
}
