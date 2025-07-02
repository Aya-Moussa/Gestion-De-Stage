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
    public class StageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/stage
        [HttpGet]
        public async Task<IEnumerable<Stage>> GetStages()
        {
            return await _mediator.Send(new GetAllGenericQuery<Stage>());
        }

        // GET: api/stage/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStage(Guid id)
        {
            var result = await _mediator.Send(new GetAllGenericQuery<Stage>(s => s.Id == id));
            var stage = result is null ? null : System.Linq.Enumerable.FirstOrDefault(result);

            if (stage == null)
                return NotFound("Stage not found");

            return Ok(stage);
        }

        // POST: api/stage
        [HttpPost]
        public async Task<IActionResult> PostStage([FromBody] Stage stage)
        {
            var result = await _mediator.Send(new PostGeneric<Stage>(stage));
            return Ok(result);
        }

        // PUT: api/stage
        [HttpPut]
        public async Task<IActionResult> PutStage([FromBody] Stage stage)
        {
            if (stage == null || stage.Id == Guid.Empty)
                return BadRequest("Stage non valide.");

            var result = await _mediator.Send(new PutGeneric<Stage>(stage));

            if (result == "Update succeeded" || result == "Update Done")
                return Ok(result);

            return StatusCode(500, result);
        }

        // DELETE: api/stage/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStage(Guid id)
        {
            var result = await _mediator.Send(new DeleteGeneric<Stage>(id));

            if (result == "Remove succeeded" || result == "Delete Done")
                return Ok(result);

            return StatusCode(500, result);
        }
    }
}
