﻿using IBuyServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IBuyServer.Controllers
{
    public class PurchasedItemsController : ApiController
    {

        private PurchasedItem[] purchasedItemsMock = new PurchasedItem[]
        {
            new PurchasedItem("0001", "Oolong Tea", "Tie guan in chinese tea"),
            new PurchasedItem("0002", "HP Laptop", "hp probook sdf3434 series"),
            new PurchasedItem("0003", "Washing Machine", "Really expensive washing machine")
        };

        // GET: api/PurchasedItems
        public List<PurchasedItem> GetPurchasedItems()
        {
            return this.purchasedItemsMock.ToList();
        }

        // GET: api/PurchasedItems/5
        public PurchasedItem GetPurchasedItem(string id)
        {
            PurchasedItem target = Array.Find(this.purchasedItemsMock, (PurchasedItem item) => item.Id == id );
            if (target === null)
            {
                return null;
            }
            return target;
        }

        // POST: api/PurchasedItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PurchasedItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PurchasedItems/5
        public void Delete(int id)
        {
        }
    }
}