using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.DTOs
{
    public class StageDTO
    {
        public Guid Id { get; set; }
        public Guid StagiaireId { get; set; }
        public Guid OffreId { get; set; }
        public Guid EncadrantId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Sujet { get; set; }
    }
}
