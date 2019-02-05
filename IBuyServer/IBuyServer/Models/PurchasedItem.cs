using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IBuyServer.Models
{
    public class PurchasedItem
    {

        public PurchasedItem()
        {
            this.Category = new PurchaseCategory
            {
                Id = "0000_DEFAULT_CATEGORY_ID",
                Name = "Default",
                Items = new List<PurchasedItem>()
            };
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PurchaseCategory Category { get; set; }
    }
}