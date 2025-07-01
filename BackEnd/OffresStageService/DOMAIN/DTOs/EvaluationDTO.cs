using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.DTOs
{
    public class EvaluationDTO
    {
        public Guid Id { get; set; }
        public Guid StageId { get; set; }
        public int NoteTechnique { get; set; }
        public int NoteComportementale { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateEvaluation { get; set; }
    }
}
