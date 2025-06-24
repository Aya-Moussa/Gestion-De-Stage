using DOMAIN.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Commands
{
    public class SignUpCommand : IRequest<string>
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; }
        public string Departement { get; set; }
        public string Poste { get; set; }
        public bool IsAffected { get; set;}
        public string Discriminator { get; set; }
    }
}
