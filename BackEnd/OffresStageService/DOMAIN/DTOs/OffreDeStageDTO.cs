using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.DTOs
{
    public class OffreDeStageDTO
    {
        public Guid Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Domaine { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
