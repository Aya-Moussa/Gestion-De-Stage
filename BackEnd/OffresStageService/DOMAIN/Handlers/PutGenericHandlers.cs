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
        public async Task<string> Handle(PutGeneric<T> request, CancellationToken cancellationToken)
        {
            var result = await repository.UpdateAsync(request.Obj);
            return result;
        }


    }
}