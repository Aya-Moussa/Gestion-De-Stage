using DOMAIN.Commands;
using DOMAIN.Models;
using DOMAIN.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntretienController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntretienController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/entretien
        [HttpGet]
        public async Task<IEnumerable<Entretien>> GetEntretiens()
        {
            return await _mediator.Send(new GetAllGenericQuery<Entretien>(
                includes: query => query.Include(e => e.Stage)
            ));


        }

        // GET: api/entretien/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntretien(Guid id)
        {
            var result = await _mediator.Send(new GetAllGenericQuery<Entretien>(e => e.Id == id));
            var entretien = result is null ? null : System.Linq.Enumerable.FirstOrDefault(result);

            if (entretien == null)
                return NotFound("Entretien non trouvé");

            return Ok(entretien);
        }

        // POST: api/entretien
        [HttpPost]
        public async Task<IActionResult> PostEntretien([FromBody] Entretien entretien)
        {
            var result = await _mediator.Send(new PostGeneric<Entretien>(entretien));
            return Ok(result);
        }

        // PUT: api/entretien
        [HttpPut]
        public async Task<IActionResult> PutEntretien([FromBody] Entretien entretien)
        {
            if (entretien == null || entretien.Id == Guid.Empty)
                return BadRequest("Entretien non valide.");

            var result = await _mediator.Send(new PutGeneric<Entretien>(entretien));

            if (result == "Update succeeded" || result == "Update Done")
                return Ok(result);

            return StatusCode(500, result);
        }

        // DELETE: api/entretien/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntretien(Guid id)
        {
            var result = await _mediator.Send(new DeleteGeneric<Entretien>(id));

            if (result == "Remove succeeded" || result == "Delete Done")
                return Ok(result);

            return StatusCode(500, result);
        }
    }
}
