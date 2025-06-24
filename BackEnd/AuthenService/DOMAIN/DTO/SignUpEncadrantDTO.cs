using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOMAIN.DTO
{
    public class SignUpEncadrantDTO { 
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }

    [Required]
    [MaxLength(50)]
    public string Prenom { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
    public string MotDePasse { get; set; }
    [Required]
    public string Poste { get; set; }
    }
}
