using DATA.Repository;
using DOMAIN.Interfaces;
using DOMAIN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;
        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UserExists(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
                return BadRequest("Invalid ID");

            var user = await _repository.GetUserByIdAsync(guid);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.GetAllUsersAsync();
            return Ok(users);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] Utilisateur updatedUser)
        {
            if (!Guid.TryParse(id, out Guid guid))
                return BadRequest("Invalid ID");

            var existingUser = await _repository.GetUserByIdAsync(guid);
            if (existingUser == null) return NotFound();

            // Update the relevant fields
            existingUser.Prenom = updatedUser.Prenom;
            existingUser.Nom = updatedUser.Nom;
            existingUser.Email = updatedUser.Email;

            // Add other fields as needed

            await _repository.UpdateUserAsync(existingUser);
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
                return BadRequest("Invalid ID");

            var user = await _repository.GetUserByIdAsync(guid);
            if (user == null) return NotFound();

            await _repository.DeleteUserAsync(user);
            return NoContent();
        }
    }
}
