using DOMAIN.Commands;
using DOMAIN.DTO;
using MediatR;
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
    public class SignUpController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SignUpController (IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("SignUp/RH/Encadrant")]
        public async Task<IActionResult> SignUpEncadrantViaRH([FromBody] SignUpEncadrantDTO dto)
        {
            var command = new SignUpCommand
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                MotDePasse = dto.MotDePasse,
                Role = "Encadrant",
                Poste = dto.Poste

            };

            var token = await _mediator.Send(command);
            return Ok(token);
        }
        [HttpPost("SignUp/RH/RH")]
        public async Task<IActionResult> SignUpRHViaRH([FromBody] SignUpRHDTO dto)
        {
            var command = new SignUpCommand
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                MotDePasse = dto.MotDePasse,
                Role = "RH",
                Departement =dto.Departement

            };

            var token = await _mediator.Send(command);
            return Ok(token);
        }

        [HttpPost("SignUp/Stagiaire")]
        public async Task<IActionResult> SignUpStagiaire([FromBody] SignUpDTO dto)
        {
            var command = new SignUpCommand
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                MotDePasse = dto.MotDePasse,
                Role = "Stagiaire",
                Discriminator= "Stagiaire"
            };

            var token = await _mediator.Send(command);
            return Ok(token);
        }

    }
}
