using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
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
                return context.PurchaseRecords.AsNoTracking().ToList();
            }
        }

        public PurchaseRecord Get(Guid id)
        {
            using (var context = new IBuyContext())
            {
                return GetItemById<PurchaseRecord>(context.PurchaseRecords, id);
            }
        }

        public PurchaseRecord Add(PurchaseRecord newRecord)
        {
            using (var context = new IBuyContext())
            {
                PurchaseRecord addedRecord = context.PurchaseRecords.Add(newRecord);
                context.SaveChanges();
                return addedRecord;
            }
        }

        public PurchaseRecord Update(PurchaseRecord updated)
        {
            using (var context = new IBuyContext())
            {
                PurchaseRecord record = GetItemById<PurchaseRecord>(context.PurchaseRecords, updated.Id);
                context.Entry(record).CurrentValues.SetValues(updated);
                context.SaveChanges();
                return updated;
            }
        }

        public Guid Delete(Guid recordId)
        {
            using (var context = new IBuyContext())
            {
                PurchaseRecord record = GetItemById<PurchaseRecord>(context.PurchaseRecords, recordId);
                context.PurchaseRecords.Remove(record);
                context.SaveChanges();
                return recordId;
            }
        }

        private T GetItemById<T>(DbSet<T> dbSet, Guid id) where T : class
        {
            T item = dbSet.Find(id);
            if (item == null)
            {
                throw new NullReferenceException("Purchase record Not found");
            }

            return item;
        }
    }
}
