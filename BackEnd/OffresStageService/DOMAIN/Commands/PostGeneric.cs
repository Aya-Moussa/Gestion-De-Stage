using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Commands
{
    public class PostGeneric<T> :IRequest<string> where T : class
    {
        public PostGeneric(T obj)
        {
            Obj = obj;

        }
        public T Obj { get; }
    }
}
