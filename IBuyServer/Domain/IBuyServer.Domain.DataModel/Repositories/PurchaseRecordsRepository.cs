using IBuyServer.Domain.DataModel.Context;
using IBuyServer.Domain.Models.Entities;
using IBuyServer.Infrastructure.DataAccess;

namespace IBuyServer.Domain.DataModel.Repositories
{
    public class PurchaseRecordsRepository : EntityRepositoryBase<PurchaseRecord, IBuyContext>
    {
        public PurchaseRecordsRepository() : base(new IBuyContext())
        {
        }
    }
}
