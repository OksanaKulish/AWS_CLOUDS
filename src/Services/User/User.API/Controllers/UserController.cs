using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Repositories;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase 
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repository, ILogger<UserController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET api/v1/User
        /// <summary>
        /// This will show all existed Users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var user = await _repository.GetUsers();
            return Ok(user);
        }

        /// <summary>
        /// This will show user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}", Name = "GetUsers")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> GetUserById(string id)
        {
            var user = await _repository.GetUser(id);
            if (user == null)
            {
                _logger.LogError($"User with id: {id}, not found.");
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/v1/User
        /// <summary>
        /// This will create user.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> CreateUser([FromBody] Users user)
        {
            await _repository.CreateUser(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            return Ok(await _repository.UpdateUser(user));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            return Ok(await _repository.DeleteUser(id));
        }
    }
}
