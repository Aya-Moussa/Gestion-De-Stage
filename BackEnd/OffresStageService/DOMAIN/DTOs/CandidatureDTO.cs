using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.DTOs
{
    public enum StatutCandidature
    {
        EnAttente,
        Acceptee,
        Refusee
    }
    public class CandidatureDTO
    {
         public Guid Id { get; set; }
        public Guid StagiaireId { get; set; }
        public Guid OffreId { get; set; }
        public DateTime DateCandidature { get; set; }
        public StatutCandidature Statut { get; set; }
    }
}
