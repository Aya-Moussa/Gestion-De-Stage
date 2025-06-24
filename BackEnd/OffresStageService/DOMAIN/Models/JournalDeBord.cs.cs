using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class JournalDeBord
    {
        public Guid Id { get; set; }
        public Guid StagiaireId { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }

        public ICollection<CommentaireEncadrant> Commentaires { get; set; }
    }
}
