using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuyServer.Infrastructure.DataAccess
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime CreationDate { get; set; }
        DateTime ModificationDate { get; set; }
    }
}
