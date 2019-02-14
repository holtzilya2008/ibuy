using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using IBuyServer.Domain.Models.Entities;
using IBuyServer.Infrastructure.DataAccess;

namespace IBuyServer.Domain.DataModel.Context
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class IBuyContext : DbContext
    {
        public DbSet<PurchaseRecord> PurchaseRecords { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public override int SaveChanges()
        { 
            SetDates();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SetDates();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetDates()
        {
            var now = DateTime.UtcNow;

            var entries = ChangeTracker.Entries<IEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreationDate = now;
                    entry.Entity.ModificationDate = now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModificationDate = now;
                }
            }
        }
    }
}
