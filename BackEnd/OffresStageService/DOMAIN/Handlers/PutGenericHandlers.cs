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
    public class PutGenericHandlers<T> : IRequestHandler<PutGeneric<T>, string> where T : class
    {
        private readonly IRepository<T> repository;

        public PutGenericHandlers(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(PutGeneric<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Update(request.Obj);
            return Task.FromResult(result);
        }

    }
}
