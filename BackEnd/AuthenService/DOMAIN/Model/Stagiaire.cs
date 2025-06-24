using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Model
{
    public class Stagiaire : Utilisateur
    {
        public bool IsAffected { get; set; } = false;

    }
}
