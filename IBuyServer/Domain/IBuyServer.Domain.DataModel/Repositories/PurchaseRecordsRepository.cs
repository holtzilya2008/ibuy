using System;
using System.Collections.Generic;
using System.Data;
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

        public PurchaseRecord Add(PurchaseRecord newRecord)
        {
            using (var context = new IBuyContext())
            {
                PurchaseRecord addedRecord = context.PurchaseRecords.Add(newRecord);
                context.SaveChanges();
                return addedRecord;
            }
        }

        public Guid Delete(Guid recordId)
        {
            using (var context = new IBuyContext())
            {
                PurchaseRecord record = context.PurchaseRecords.Find(recordId);
                if (record == null)
                {
                    throw new NullReferenceException("Purchase record Not found");
                }
                context.PurchaseRecords.Remove(record);
                context.SaveChanges();
                return recordId;
            }
        }
    }
}
