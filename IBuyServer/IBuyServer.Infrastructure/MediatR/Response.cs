using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuyServer.Infrastructure.MediatR
{
    public class Response<T>
    {
        public T Value { get; }

        public Response(T value)
        {
            Value = value;
        }
    }
}
