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
    class LoginHandler : IRequestHandler<LoginCommand, string>

    {
        private readonly IRepository _repository;
        public LoginHandler (IRepository repository)
        {
            _repository = repository;
        }
       public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
{
    var user = await _repository.GetByEmailAsync(request.Email, request.Role);
    if (user == null) return null;

    bool passwordValid = _repository.VerifyPassword(user.MotDePasse, request.MotDePasse);
    if (!passwordValid) return null;

    return _repository.GenerateToken(user);
}

    }
}
