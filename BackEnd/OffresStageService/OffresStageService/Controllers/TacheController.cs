using AutoMapper;
using AutoMapper.QueryableExtensions;
using DOMAIN.Commands;
using DOMAIN.DTOs;
using DOMAIN.Interface;
using DOMAIN.Models;
using DOMAIN.Queries;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Tache> _genericRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TacheController(AppDbContext context, IRepository<Tache> repository, IMediator mediator, IMapper mapper)
        {
            _genericRepository = repository;
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }
        //Authorize(Roles ="Encadrant,Stagiaire,RH")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TacheDTO>>> GetAllStageAsync()
        {
            var result = await _mediator.Send(
                new GetAllGenericQuery<Tache>()
                );
            var resultdto = _mapper.Map<IEnumerable<TacheDTO>>(result);
            return Ok(resultdto);
        }
        //[Authorize(Roles = "Encadrant,Stagiaire,RH")]
        [HttpGet("{id}")]
        public async Task<ActionResult>GetTacheById(Guid id)
        {
            var result = await _mediator.Send(
                new GetGenericQueryById<Tache>
                (condition: o => o.Id ==id)
                );
            if (result == null)
                return BadRequest("Unable to find this Tache");
            var resultdto = _mapper.Map<TacheDTO>(result);
            return Ok(resultdto);
        }
       // [Authorize (Roles ="Encadrant,RH")]
        [HttpPost]
        public async Task<ActionResult>AddTacheAsync([FromBody] TacheDTO dto)
        {
            var tache = _mapper.Map<Tache>(dto);
            var result = await _mediator.Send
                (new PostGeneric<Tache>(tache));
            return Ok(result);
        }
        //[Authorize(Roles = "Encadrant,RH")]
        [HttpDelete]
        public async Task<ActionResult> DeleteGenericTache(Guid id)
        {
            var result = await _mediator.Send(new DeleteGeneric<Tache>(id));
            return Ok("Deleted successfully");
        }
        //[Authorize(Roles ="Stagiaire")]
        [HttpPut]
        public async Task<ActionResult> UpdatTache(TacheDTO dto)
        {
            var entity = _mapper.Map<Tache>(dto);
            var result = await _mediator.Send(new PutGeneric<Tache>(entity));
            return Ok("updated!");
        }
    }
}
