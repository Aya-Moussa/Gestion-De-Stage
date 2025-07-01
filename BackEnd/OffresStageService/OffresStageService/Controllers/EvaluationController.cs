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
        public class EvaluationController : ControllerBase
        {
            private readonly AppDbContext _context;
            private readonly IRepository<Evaluation> _genericRepository;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public EvaluationController(AppDbContext context, IRepository<Evaluation> repository, IMediator mediator, IMapper mapper)
            {
                _genericRepository = repository;
                _mediator = mediator;
                _mapper = mapper;
                _context = context;
            }
            //[Authorize(Roles = "Encadrant,Stagiaire,RH")]
            [HttpGet]
            public async Task<ActionResult<IEnumerable<EvaluationDTO>>> GetAllEvaluationAsync()
            {
                var result = await _mediator.Send(
                    new GetAllGenericQuery<Evaluation>()
                    );
                var resultdto = _mapper.Map<IEnumerable<EvaluationDTO>>(result);
                return Ok(resultdto);
            }
            //[Authorize(Roles = "Encadrant,Stagiaire,RH")]
            [HttpGet("{id}")]
            public async Task<ActionResult> GetEvaluationById(Guid id)
            {
                var result = await _mediator.Send(
                    new GetGenericQueryById<Evaluation>
                    (condition: o => o.Id == id)
                    );
                if (result == null)
                    return BadRequest("Unable to find this Tache");
                var resultdto = _mapper.Map<EvaluationDTO>(result);
                return Ok(resultdto);
            }
            //[Authorize(Roles = "Encadrant,RH")]
            [HttpPost]
            public async Task<ActionResult> AddEvaluationAsync([FromBody] EvaluationDTO dto)
            {
                var evaluation = _mapper.Map<Evaluation>(dto);
                var result = await _mediator.Send
                    (new PostGeneric<Evaluation>(evaluation));
                return Ok(result);
            }
            //[Authorize(Roles = "Encadrant,RH")]
            [HttpDelete]
            public async Task<ActionResult> DeleteGenericEvaluation(Guid id)
            {
                var result = await _mediator.Send(new DeleteGeneric<Evaluation>(id));
                return Ok("Deleted successfully");
            }
            //[Authorize(Roles ="Stagiaire")]
            [HttpPut]
            public async Task<ActionResult> UpdateEvaluation(EvaluationDTO dto)
            {
                var entity = _mapper.Map<Evaluation>(dto);
                var result = await _mediator.Send(new PutGeneric<Evaluation>(entity));
                return Ok("updated!");
            }
        }
    }

