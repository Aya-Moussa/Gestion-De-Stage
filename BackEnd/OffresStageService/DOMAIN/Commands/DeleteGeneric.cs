using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Commands
{
    public class DeleteGeneric<T> : IRequest<string> where T : class
    {
        public DeleteGeneric(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }

    }
}
