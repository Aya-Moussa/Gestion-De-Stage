using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.DTOs
{
    public class TacheDTO
    {
        public Guid Id { get; set; }
        public Guid StageId { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Statut { get; set; }
    }
}
