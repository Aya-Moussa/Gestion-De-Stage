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
    public class CandidatureController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Candidature> _genericRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CandidatureController(AppDbContext context, IRepository<Candidature> repository, IMediator mediator, IMapper mapper)
        {
            _genericRepository = repository;
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        [Authorize(Roles = "RH,Encadrant,Stagiaire")]
        [HttpGet]
       public async Task<ActionResult<IEnumerable<CandidatureDTO>>> GetCandidatureAsync()
        {
            var result = await _mediator.Send(
                new GetAllGenericQuery<Candidature>()
                );
            return Ok(result);
        }
        //[Authorize(Roles = "RH,Encadrant,Stagiaire")]
        [HttpGet("{id}")]
        public async Task<ActionResult>GetCandidatureByID(Guid id)
        {
            var result = await _mediator.Send(new GetGenericQueryById<Candidature>(
                condition: o => o.Id == id
                ));
            if (result == null)
                return BadRequest("Unable to find this candidature");
            var resultdto = _mapper.Map<CandidatureDTO>(result);
            return Ok(resultdto);
        }
        //[Authorize(Roles = "Stagiaire")]
        [HttpPost]
        public async Task<ActionResult> AddAsync ([FromBody] CandidatureDTO dto)
        {
            var entity = _mapper.Map<Candidature>(dto);
            var result = await _mediator.Send(new PostGeneric<Candidature>(entity));
            return Ok(result);
        }
        //[Authorize(Roles ="RH,Stagiaire")]
        [HttpDelete]
        public async Task <ActionResult> DeleteGenericCandidature(Guid id)
        {
            var result = await _mediator.Send(new DeleteGeneric<Candidature>(id));
            return Ok("Deleted successfully");
        }
        //[Authorize(Roles ="Stagiaire")]
        [HttpPut]
        public async Task <ActionResult> UpdateCandidature(CandidatureDTO dto)
        {
            var entity = _mapper.Map<Candidature>(dto);
            var result = await _mediator.Send(new PutGeneric<Candidature>(entity));
            return Ok("updated!");
        }
        





    }
}
