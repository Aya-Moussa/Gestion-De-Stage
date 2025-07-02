using DOMAIN.Commands;
using DOMAIN.Models;
using DOMAIN.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentaireEncadrantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentaireEncadrantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/CommentaireEncadrant
        [HttpGet]
        public async Task<IEnumerable<CommentaireEncadrant>> GetCommentaires()
        {
            return await _mediator.Send(new GetAllGenericQuery<CommentaireEncadrant>());
        }

        // GET: api/CommentaireEncadrant/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentaire(Guid id)
        {
            var result = await _mediator.Send(new GetAllGenericQuery<CommentaireEncadrant>(c => c.Id == id));
            var commentaire = result is null ? null : System.Linq.Enumerable.FirstOrDefault(result);

            if (commentaire == null)
                return NotFound("Commentaire non trouvé");

            return Ok(commentaire);
        }

        // POST: api/CommentaireEncadrant
        [HttpPost]
        public async Task<IActionResult> PostCommentaire([FromBody] CommentaireEncadrant commentaire)
        {
            if (commentaire == null)
                return BadRequest("Commentaire invalide");

            var result = await _mediator.Send(new PostGeneric<CommentaireEncadrant>(commentaire));
            return Ok(result);
        }

        // PUT: api/CommentaireEncadrant
        [HttpPut]
        public async Task<IActionResult> PutCommentaire([FromBody] CommentaireEncadrant commentaire)
        {
            if (commentaire == null || commentaire.Id == Guid.Empty)
                return BadRequest("Commentaire non valide.");

            var result = await _mediator.Send(new PutGeneric<CommentaireEncadrant>(commentaire));

            if (result == "Update succeeded" || result == "Update Done")
                return Ok(result);

            return StatusCode(500, result);
        }

        // DELETE: api/CommentaireEncadrant/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaire(Guid id)
        {
            var result = await _mediator.Send(new DeleteGeneric<CommentaireEncadrant>(id));

            if (result == "Remove succeeded" || result == "Delete Done")
                return Ok(result);

            return StatusCode(500, result);
        }
    }
}
