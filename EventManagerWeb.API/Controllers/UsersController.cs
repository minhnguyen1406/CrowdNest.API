using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EventManagerWeb.Contracts;
using EventManagerWeb.Entity;
using EventManagerWeb.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EventManagerWeb.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace EventManagerWeb.API.Controllers
{
    [Route("api/EventManagerWeb")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;
        private readonly IUserService userService;


        public UsersController(IUserBusiness userBusiness, IUserService userService)
        {
            this.userBusiness = userBusiness;
            this.userService = userService;
        }

        /// <summary>
        /// This is to add a new User
        /// </summary>
        /// <param name="user">Pass user object</param>
        /// <returns>Returns true/false</returns>
        [HttpPost]
        [Route("users")]
        public async Task<ActionResult<int>> CreateUser([Required][FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid");
            }

            var response = await this.userBusiness.AddUser(user);

            return Ok(response);
        }

        /// <summary>
        /// This is to validate the user and render the token
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Return a response</returns>
        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = await userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        /// <summary>
        /// Get Users according to page size and page index
        /// </summary>
        /// <returns>Return a list of user</returns>
        [HttpGet]
        [Route("users")]
        [Helpers.Authorize] //This is custom authorize attribute
        public async Task<ActionResult<List<User>>> GetUsers([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var response = await this.userBusiness.GetUsers(pageIndex, pageSize);
            return Ok(response);
        }


        /// <summary>
        /// Get User by username
        /// </summary>
        /// <returns>Return a user</returns>
        [HttpGet]
        [Route("users/username/{username}")]
        [AllowAnonymous] //This is custom authorize attribute
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var response = await this.userBusiness.GetUserByUsername(username);
            return Ok(response);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <returns>Return a user</returns>
        [HttpGet]
        [Route("users/id/{id}")]
        [Helpers.Authorize]  //This is custom authorize attribute
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var response = await this.userBusiness.GetUserById(id);
            return Ok(response);
        }

        /// <summary>
        /// Get User count
        /// </summary>
        /// <returns>Return a user</returns>
        [HttpGet]
        [Route("users-count")]
        [Helpers.Authorize]  //This is custom authorize attribute
        public async Task<ActionResult<int>> GetUsersCount()
        {
            var response = await this.userBusiness.GetUsersCount();
            return Ok(response);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="users">Given user information to update</param>
        /// <returns>Return the id of updated user</returns>
        [HttpPut]
        [Route("users")]
        [Helpers.Authorize] //This is custom authorize attribute
        public async Task<ActionResult<int>> SaveUpdatedUser(User userModel)
        {
            if (this.userBusiness.GetUserById(userModel.Id) == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }
            var response = await this.userBusiness.EditUser(userModel);

            return Ok(response);
        }

    }
}
