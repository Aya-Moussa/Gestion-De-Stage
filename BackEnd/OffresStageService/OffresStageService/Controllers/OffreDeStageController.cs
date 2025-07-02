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
    public class OffreDeStageController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRepository<OffreDeStage> _genericRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OffreDeStageController(AppDbContext context, IRepository<OffreDeStage> repository, IMediator mediator, IMapper mapper)
        {
            _genericRepository = repository;
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        [Authorize(Roles = "RH,Encadrant,Stagiaire")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OffreDeStageDTO>>> GetOffreStageAsync()
        {
            var Offrestages = await _context.Offres
                .Include(s => s.Candidatures)
                .Include(s => s.Stages)
                .AsNoTracking()
                .ToListAsync();
            var OffrestageDtos = _mapper.Map<List<OffreDeStageDTO>>(Offrestages);

            return Ok(OffrestageDtos);
        }
        [Authorize(Roles = "RH,Encadrant,Stagiaire")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOffreById(Guid id)
        {
            var result = await _mediator.Send(
                new GetGenericQueryById<OffreDeStage>(
                    condition: o => o.Id ==id
                    )
                    );
            if (result == null)
                return BadRequest("Unable to find this offre");
            return Ok(result);   
        }

        //[Authorize(Roles = "RH")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] OffreDeStageDTO dto)
        {
            var entity = _mapper.Map<OffreDeStage>(dto);
            var result = await _mediator.Send(new PostGeneric<OffreDeStage>(entity));
            return Ok(result);
        }
       // [Authorize(Roles ="RH")]
        [HttpDelete("DeleteOffreStage")]
        public async Task<IActionResult> DeleteGeneric(Guid id){
            var result = await _mediator.Send(new DeleteGeneric<OffreDeStage>(id));
            return Ok("Deleted successfully");


        }
        //[Authorize(Roles ="RH")]
        [HttpPut]
        public async Task<ActionResult> UpdateCandidature(OffreDeStageDTO dto)
        {
            var entity = _mapper.Map<OffreDeStage>(dto);
            var result = await _mediator.Send(new PutGeneric<OffreDeStage>(entity));
            return Ok("updated!");
        }

    }
}
