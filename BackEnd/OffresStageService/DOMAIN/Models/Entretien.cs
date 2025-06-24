using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class Entretien
    {
        public Guid Id { get; set; }
        public Guid StageId { get; set; }
        public DateTime DateEntretien { get; set; }
        public string Objet { get; set; }
        public string CompteRendu { get; set; }

        public Stage Stage { get; set; }
    }
}
