using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using IBuyServer.Database;
using IBuyServer.Models;

namespace IBuyServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PurchasedItemsController : ApiController
    {
        private PurchasesDB db = new PurchasesDB();

        // GET: api/PurchasedItems
        public IQueryable<PurchasedItem> GetPurchasedItems()
        {
            return db.PurchasedItems;
        }

        // GET: api/PurchasedItems/5
        [ResponseType(typeof(PurchasedItem))]
        public async Task<IHttpActionResult> GetPurchasedItem(string id)
        {
            PurchasedItem purchasedItem = await db.PurchasedItems.FindAsync(id);
            if (purchasedItem == null)
            {
                return NotFound();
            }

            return Ok(purchasedItem);
        }

        // PUT: api/PurchasedItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchasedItem(string id, PurchasedItem purchasedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchasedItem.Id)
            {
                return BadRequest();
            }

            db.Entry(purchasedItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasedItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PurchasedItems
        [ResponseType(typeof(PurchasedItem))]
        public async Task<IHttpActionResult> PostPurchasedItem(PurchasedItem purchasedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            purchasedItem.Id = Guid.NewGuid().ToString();
            db.PurchasedItems.Add(purchasedItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchasedItem.Id }, purchasedItem);
        }

        // DELETE: api/PurchasedItems/5
        [ResponseType(typeof(PurchasedItem))]
        public async Task<IHttpActionResult> DeletePurchasedItem(string id)
        {
            PurchasedItem purchasedItem = await db.PurchasedItems.FindAsync(id);
            if (purchasedItem == null)
            {
                return NotFound();
            }

            db.PurchasedItems.Remove(purchasedItem);
            await db.SaveChangesAsync();

            return Ok(purchasedItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchasedItemExists(string id)
        {
            return db.PurchasedItems.Count(e => e.Id == id) > 0;
        }
    }
}