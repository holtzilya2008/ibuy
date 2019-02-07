using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Contracts;
using IBuyServer.Logic.Handlers.PurchaseRecords;

namespace IBuyServer.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PurchaseRecordsController : ApiController
    {
        // GET: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO[]))]
        public IHttpActionResult Get()
        {
            var handler = new GetPurchaseRecordsHandler();
            var result = handler.Handle(null);
            return Ok(result);
        }

        // GET: api/PurchaseRecords/5
        [ResponseType(typeof(PurchaseRecordDTO))]
        public IHttpActionResult Get(string id)
        {
            var result = new GetPurchaseRecordById().Handle(id);
            return Ok(result);
        }

        // POST: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO))]
        public IHttpActionResult Post([FromBody] AddPurchaseRecordDTO newRecord)
        {
            var result = new AddPurchaseRecordHandler().Handle(newRecord);
            return Ok(result);
        }

        // PUT: api/PurchaseRecords/
        [ResponseType(typeof(PurchaseRecordDTO))]
        public IHttpActionResult Put([FromBody] PurchaseRecordDTO updated)
        {
            var result = new UpdatePurchaseRecord().Handle(updated);
            return Ok(result);
        }

        // DELETE: api/PurchaseRecords/5
        [ResponseType(typeof(string))]
        public IHttpActionResult Delete(string id)
        {
            var result = new DeletePurchaseRecordHandler().Handle(id);
            return Ok(result);
        }
    }
}
