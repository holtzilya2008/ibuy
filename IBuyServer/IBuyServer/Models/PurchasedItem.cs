using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBuyServer.Models
{
    public class PurchasedItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PurchasedItem(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = Description;
        }
    }
}