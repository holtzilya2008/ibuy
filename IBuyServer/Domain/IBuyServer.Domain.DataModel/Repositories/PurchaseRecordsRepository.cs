using System.Collections.Generic;
using System.Linq;
using IBuyServer.Domain.DataModel.Context;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Domain.DataModel.Repositories
{
    public class PurchaseRecordsRepository
    {
        public List<PurchaseRecord> All()
        {
            using (var context = new IBuyContext())
            {
                return context.PurchaseRecords.ToList();
            }
        }
    }
}
