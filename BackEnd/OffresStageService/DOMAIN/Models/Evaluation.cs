using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid StageId { get; set; }
        public int NoteTechnique { get; set; }
        public int NoteComportementale { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateEvaluation { get; set; }
        public bool AttestationAffected { get; set; } = false;

        public Stage Stage { get; set; }
    }
}
