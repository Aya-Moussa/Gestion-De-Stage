using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class Stage
    {
         public Guid Id { get; set; }
        public Guid StagiaireId { get; set; }
        public Guid OffreId { get; set; }
        public Guid EncadrantId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Sujet { get; set; }
        public ICollection<Tache> Taches { get; set; }
        public Evaluation Evaluation { get; set; }
        public OffreDeStage Offre { get; set; }
    }
}
