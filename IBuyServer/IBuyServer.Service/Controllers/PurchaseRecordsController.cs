using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Logic.Engines;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace IBuyServer.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PurchaseRecordsController : ApiController
    {
        private IPurchaseRecordsEngine _engine;

        public PurchaseRecordsController(IPurchaseRecordsEngine engine)
        {
            _engine = engine;
        }

        // GET: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO[]))]
        public IHttpActionResult Get()
        {
            var result = _engine.GetAllPurchaseRecords();
            return Ok(result);
        }

        // GET: api/PurchaseRecords/{id}
        [ResponseType(typeof(PurchaseRecordDetailsDTO))]
        public IHttpActionResult Get(string id)
        {
            var result = _engine.GetPurchaseRecordDetails(id);
            return Ok(result);
        }

        // POST: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO))]
        public IHttpActionResult Post([FromBody] AddPurchaseRecordDTO newRecord)
        {
            var result = _engine.AddPurchaseRecord(newRecord);
            return Ok(result);
        }

        // PUT: api/PurchaseRecords/
        [ResponseType(typeof(PurchaseRecordDTO))]
        public IHttpActionResult Put([FromBody] PurchaseRecordDTO updated)
        {
            var result = _engine.UpdatePurchaseRecord(updated);
            return Ok(result);
        }

        // DELETE: api/PurchaseRecords/{id}
        [ResponseType(typeof(string))]
        public IHttpActionResult Delete(string id)
        {
            var result = _engine.DeletePurchaseRecord(id);
            return Ok(result);
        }
    }
}
