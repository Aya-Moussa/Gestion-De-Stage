using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOMAIN.DTO
{
    public class SignUpDTO
    {
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
        [RegularExpression("Stagiaire|Encadrant|RH", ErrorMessage = "Le rôle doit être 'Stagiaire', 'Encadrant' ou 'RH'.")]
        public string Role { get; set; } 
    }
}
