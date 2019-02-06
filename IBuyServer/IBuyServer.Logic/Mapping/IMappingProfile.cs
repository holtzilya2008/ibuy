using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuyServer.Logic.Mapping
{
    interface IMappingProfile<TDto, TEntity>
    {
        TDto ToDto(TEntity entity);
        TEntity ToEntity(TDto dto);
    }
}
