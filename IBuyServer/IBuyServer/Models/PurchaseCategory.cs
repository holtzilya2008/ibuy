using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IBuyServer.Models
{
    public class PurchaseCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PurchasedItem> Items { get; set; }
    }
}