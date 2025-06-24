using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class Tache
    {
        public Guid Id { get; set; }
        public Guid StageId { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Statut { get; set; } // À faire, En cours, Terminée

        public Stage Stage { get; set; }

    }
}
