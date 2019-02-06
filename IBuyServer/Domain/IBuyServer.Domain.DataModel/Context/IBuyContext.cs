using System.Data.Entity;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Domain.DataModel.Context
{
    public class IBuyContext : DbContext
    {
        public DbSet<PurchaseRecord> PurchaseRecords { get; set; }
    }
}
