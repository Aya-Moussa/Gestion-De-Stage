using DOMAIN.Commands;
using DOMAIN.Models;
using DOMAIN.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JournalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/journal
        [HttpGet]
        public async Task<IEnumerable<JournalDeBord>> GetJournaux()
        {
            return await _mediator.Send(new GetAllGenericQuery<JournalDeBord>());
        }

        // GET: api/journal/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJournal(Guid id)
        {
            var result = await _mediator.Send(new GetAllGenericQuery<JournalDeBord>(j => j.Id == id));
            var journal = System.Linq.Enumerable.FirstOrDefault(result);

            if (journal == null)
                return NotFound("Journal non trouvé.");

            return Ok(journal);
        }

        // POST: api/journal
        [HttpPost]
        public async Task<IActionResult> PostJournal([FromBody] JournalDeBord journal)
        {
            var result = await _mediator.Send(new PostGeneric<JournalDeBord>(journal));
            return Ok(result);
        }

        // PUT: api/journal
        [HttpPut]
        public async Task<IActionResult> PutJournal([FromBody] JournalDeBord journal)
        {
            if (journal == null || journal.Id == Guid.Empty)
                return BadRequest("Journal non valide.");

            var result = await _mediator.Send(new PutGeneric<JournalDeBord>(journal));

            if (result == "Update succeeded" || result == "Update Done")
                return Ok(result);

            return StatusCode(500, result);
        }

        // DELETE: api/journal/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournal(Guid id)
        {
            var result = await _mediator.Send(new DeleteGeneric<JournalDeBord>(id));

            if (result == "Remove succeeded" || result == "Delete Done")
                return Ok(result);

            return StatusCode(500, result);
        }
    }
}
