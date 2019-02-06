using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuyServer.Logic.Handlers
{
    interface IHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest requestArgs);
    }
}
