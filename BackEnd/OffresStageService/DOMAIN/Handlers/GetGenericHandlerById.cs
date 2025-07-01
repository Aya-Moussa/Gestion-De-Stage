using DOMAIN.Interface;
using DOMAIN.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOMAIN.Handlers
{
    public class GetGenericHandlerById<T> : IRequestHandler<GetGenericQueryById<T>, T> where T : class
    {
        private readonly IRepository<T> repository;
        public GetGenericHandlerById(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public async Task<T> Handle(GetGenericQueryById<T> request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAsync(request.Condition, request.Includes);
            return result;
        }
    }
}

