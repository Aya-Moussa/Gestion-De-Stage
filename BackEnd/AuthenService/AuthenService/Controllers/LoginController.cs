using DOMAIN.Commands;
using DOMAIN.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("Stagiaire")]
        public async Task<IActionResult> LoginStagiaire([FromBody] LoginDTO dto)
        {
            var command = new LoginCommand
            {
                Email = dto.Email,
                MotDePasse = dto.MotDePasse,
                Role = dto.Role,
                IsStagiaire = true
            };

            var token = await _mediator.Send(command);
            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }
        [AllowAnonymous]
        [HttpPost("Personel")]
        public async Task<IActionResult> LoginPersonel([FromBody] LoginDTO dto)
        {
            var command = new LoginCommand
            {
                Email = dto.Email,
                MotDePasse = dto.MotDePasse,
                Role = dto.Role,
                IsStagiaire = false
            };

            var token = await _mediator.Send(command);
            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }
    }
}
