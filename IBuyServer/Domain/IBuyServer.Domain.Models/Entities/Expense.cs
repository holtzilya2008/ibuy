using System;
using System.ComponentModel.DataAnnotations.Schema;
using IBuyServer.Infrastructure.DataAccess;

namespace IBuyServer.Domain.Models.Entities
{
    public class Expense : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        [ForeignKey("PurchaseRecord")]
        public Guid PurchaseRecordId { get; set; }
        public virtual PurchaseRecord PurchaseRecord { get; set; }
    }
}
