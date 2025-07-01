using DOMAIN.Commands;
using DOMAIN.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOMAIN.Handlers
{
    public class AddGenericHandlers<T> : IRequestHandler<PostGeneric<T>, string> where T : class
    {

        private readonly IRepository<T> repository;
        public AddGenericHandlers(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public async Task<string> Handle(PostGeneric<T> request, CancellationToken cancellationToken)
        {
            var result = await repository.AddAsync(request.Obj);
            return result; // Pas besoin de Task.FromResult ici
        }
    }
}