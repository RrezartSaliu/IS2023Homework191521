using IS2023Homework.Domain.Identity;
using IS2023Homework.Repository.Interface;
using IS2023Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS2023Homework.Service.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUserRepository _userRepository;
        public ApplicationUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ShopApplicationUser Get(string id)
        {
            return _userRepository.GetById(id);
        }

        public List<ShopApplicationUser> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public void Insert(ShopApplicationUser user)
        {
            _userRepository.Insert(user);
        }

        public void Update(string id, string role)
        {
            var userToUpdate = this.Get(id);
            userToUpdate.Role = role;
            _userRepository.Update(userToUpdate);
        }
    }
}
