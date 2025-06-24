using System;
using System.Collections.Generic;
using System.Text;
using DOMAIN.Commands;
using DOMAIN.Interfaces;
using DOMAIN.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DOMAIN.Handlers
{
    class SignUpHandler : IRequestHandler<SignUpCommand, string>
    {
        private readonly IRepository _repository;
        public SignUpHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            Utilisateur user;
            Stagiaire s;
            Encadrant en;
            RH r;
            if (request.Role == "Stagiaire")
            {
                var stagiaire = new Stagiaire
                {
                    Nom = request.Nom,
                    Prenom = request.Prenom,
                    Email = request.Email,
                    MotDePasse = _repository.HashPassword(request.MotDePasse),
                    Role = request.Role,
                    
                    IsAffected= false
                };
                await _repository.AddUserAsync(stagiaire);
                s = stagiaire;
                var token = _repository.GenerateToken(s);
                return token;
            }
            else if (request.Role == "RH")
            {
                var rh = new RH
                {
                    Nom = request.Nom,
                    Prenom = request.Prenom,
                    Email = request.Email,
                    MotDePasse = _repository.HashPassword(request.MotDePasse),
                    Role = "RH",
                    Departement = request.Departement  
                };
                await _repository.AddRHAsync(rh);
                r = rh;
                var token = _repository.GenerateToken(rh);
                return token;
            }
            else if (request.Role == "Encadrant")
            {
                var encadrant = new Encadrant
                {
                    Nom = request.Nom,
                    Prenom = request.Prenom,
                    Email = request.Email,
                    MotDePasse = _repository.HashPassword(request.MotDePasse),
                    Role = "Encadrant",
                    Poste = request.Poste  // pass poste via SignUpCommand if needed
                };
                await _repository.AddEncadrant(encadrant);
                en = encadrant;
                var token = _repository.GenerateToken(en);
                return token;
            }
            else
            {
                return null; // invalid role
            }

            
        }

    }
}
