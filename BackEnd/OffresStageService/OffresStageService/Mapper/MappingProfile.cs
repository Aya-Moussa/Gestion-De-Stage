using AutoMapper;
using DOMAIN.DTOs;
using DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OffreDeStage, OffreDeStageDTO>().ReverseMap();
            CreateMap<Candidature, CandidatureDTO>().ReverseMap();
            CreateMap<TacheDTO, Tache>().ReverseMap();
            CreateMap<EvaluationDTO, Evaluation>().ReverseMap();
         
        }
    }
}
