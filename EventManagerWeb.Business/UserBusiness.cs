using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerWeb.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository repository;
        public UserBusiness(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> AddUser(User user)
        {
            return await this.repository.AddUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.repository.GetUserById(id);
        }

        public async Task<List<User>> GetUsers(int pageIndex, int pageSize)
        {
            return await this.repository.GetUsers(pageIndex, pageSize);
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            return await this.repository.ValidateUser(username, password);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await this.repository.GetUserByUsername(username);
        }

        public async Task<int> EditUser(User user)
        {
            return await this.repository.EditUser(user);
        }

        public async Task<int> GetUsersCount()
        {
            return await this.repository.GetUsersCount();
        }
    }
}
