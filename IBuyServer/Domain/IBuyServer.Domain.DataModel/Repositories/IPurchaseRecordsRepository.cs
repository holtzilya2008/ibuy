using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBuyServer.Domain.Models.Entities;
using IBuyServer.Infrastructure.DataAccess;

namespace IBuyServer.Domain.DataModel.Repositories
{
    public interface IPurchaseRecordsRepository : IRepository<PurchaseRecord>
    {
    }
}
