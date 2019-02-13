using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuyServer.Infrastructure.DataAccess.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(Guid id) : base($"Resource with id {id} was not found")
        {
        }
    }
}
