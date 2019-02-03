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
using System.Web.Http.Description;
using IBuyServer.Database;
using IBuyServer.Models;

namespace IBuyServer.Controllers
{
    public class PurchaseCategoriesController : ApiController
    {
        private PurchasesDB db = new PurchasesDB();

        // GET: api/PurchaseCategories
        public IQueryable<PurchaseCategory> GetPurchaseCategories()
        {
            return db.PurchaseCategories;
        }

        // GET: api/PurchaseCategories/5
        [ResponseType(typeof(PurchaseCategory))]
        public async Task<IHttpActionResult> GetPurchaseCategory(string id)
        {
            PurchaseCategory purchaseCategory = await db.PurchaseCategories.FindAsync(id);
            if (purchaseCategory == null)
            {
                return NotFound();
            }

            return Ok(purchaseCategory);
        }

        // PUT: api/PurchaseCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchaseCategory(string id, PurchaseCategory purchaseCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseCategoryExists(id))
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

        // POST: api/PurchaseCategories
        [ResponseType(typeof(PurchaseCategory))]
        public async Task<IHttpActionResult> PostPurchaseCategory(PurchaseCategory purchaseCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseCategories.Add(purchaseCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchaseCategory.Id }, purchaseCategory);
        }

        // DELETE: api/PurchaseCategories/5
        [ResponseType(typeof(PurchaseCategory))]
        public async Task<IHttpActionResult> DeletePurchaseCategory(string id)
        {
            PurchaseCategory purchaseCategory = await db.PurchaseCategories.FindAsync(id);
            if (purchaseCategory == null)
            {
                return NotFound();
            }

            db.PurchaseCategories.Remove(purchaseCategory);
            await db.SaveChangesAsync();

            return Ok(purchaseCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseCategoryExists(string id)
        {
            return db.PurchaseCategories.Count(e => e.Id == id) > 0;
        }
    }
}