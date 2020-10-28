using EventManagerWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagerWeb.Contracts
{
    public interface IUserBusiness
    {
        /// <summary>
        /// A method to add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Return id </returns>
        Task<int> AddUser(User user);

        /// <summary>
        /// A method to validate username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Return user</returns>
        Task<User> ValidateUser(string username, string password);

        /// <summary>
        /// A method to get all users according to page size and page index
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns>Return a list of user</returns>
        Task<List<User>> GetUsers(int pageIndex, int pageSize);

        /// <summary>
        /// A method to retrieve the user with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a user</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// A method to retrieve the user with username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Return a user</returns>
        Task<User> GetUserByUsername(string username);

        /// <summary>
        /// A method to retrieve the total count of users
        /// </summary>
        /// <returns>Return a user count</returns>
        Task<int> GetUsersCount();

        /// <summary>
        /// A method to update exisitng user info
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Return id</returns>
        Task<int> EditUser(User user);

    }
}
