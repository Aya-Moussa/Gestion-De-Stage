using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models
{
    public class CommentaireEncadrant
    {
        public Guid Id { get; set; }
        public Guid JournalId { get; set; }
        public Guid EncadrantId { get; set; }
        public string Texte { get; set; }
        public DateTime DateCommentaire { get; set; }

        public JournalDeBord Journal { get; set; }
    }
}
