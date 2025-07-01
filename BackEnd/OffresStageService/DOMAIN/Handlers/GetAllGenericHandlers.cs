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
    public class GetAllGenericHandlers<T> : IRequestHandler<GetAllGenericQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IRepository<T> repository;

        public GetAllGenericHandlers(IRepository<T> Repository)
        {
            repository = Repository;
        }

        public async Task<IEnumerable<T>> Handle(GetAllGenericQuery<T> request, CancellationToken cancellationToken)
        {
            var result = await repository.GetListAsync(request.Condition, request.Includes);
            return result;
        }
    }
}