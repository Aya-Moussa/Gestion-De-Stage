using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public enum StatutCandidature
    {
        EnAttente,
        Acceptee,
        Refusee
    }

    public class Candidature
    {
        public Guid Id { get; set; }
        public Guid StagiaireId { get; set; }
        public Guid OffreId { get; set; }
        public DateTime DateCandidature { get; set; }
        public StatutCandidature Statut { get; set; }
        public OffreDeStage Offre { get; set; }
    }
}
