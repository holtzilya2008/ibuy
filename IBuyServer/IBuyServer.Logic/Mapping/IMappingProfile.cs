using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuyServer.Logic.Mapping
{
    public interface IMappingProfile<TSource, TDest>
    {
        TDest Map(TSource model);
        TSource Map(TDest model);
    }
}
