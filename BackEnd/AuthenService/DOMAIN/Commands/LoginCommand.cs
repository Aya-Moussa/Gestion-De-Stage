using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Commands
{
   public  class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; }
        public bool IsStagiaire { get; set; }
    }
}
