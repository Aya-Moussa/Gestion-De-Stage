using AutoMapper;
using DOMAIN.Interface;
using DOMAIN.Models;
using DOMAIN.Queries;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffreDeStageController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Stage> GenericRepository;
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public OffreDeStageController (AppDbContext context, IRepository<Stage> repository, IMediator mediator, IMapper mapper)
        {
            this.GenericRepository = repository;
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("GetStage")]
        public async Task<IEnumerable<Stage>> GetStageAsync()
        {
            return await _mediator.Send(new GetAllGenericQuery<Stage>(null,q => q.Include(s => s.Offre).Include(s => s.Evaluation)));


        }

    }

}
