
using System.Threading.Tasks;
using Contracts.DTO.PurchaseRecordDTOs;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using IBuyServer.Logic.Handlers.PurchaseRecords;
using MediatR;

namespace IBuyServer.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PurchaseRecordsController : ApiController
    {
        private IMediator _mediator;

        public PurchaseRecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO[]))]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _mediator.Send(new GetPurchaseRecordsRequest());
            return Ok(result.Value);
        }

        //// GET: api/PurchaseRecords/{id}
        //[ResponseType(typeof(PurchaseRecordDetailsDTO))]
        //public IHttpActionResult Get(string id)
        //{
        //    var result = _engine.GetPurchaseRecordDetails(id);
        //    return Ok(result);
        //}

        // POST: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO))]
        public async Task<IHttpActionResult> Create([FromBody] AddPurchaseRecordDTO newRecord)
        {
            var result = await _mediator.Send(new AddPurchaseRecordRequest(newRecord));
            return Ok(result.Value);
        }

        //// PUT: api/PurchaseRecords/
        //[ResponseType(typeof(PurchaseRecordDTO))]
        //public IHttpActionResult Put([FromBody] PurchaseRecordDTO updated)
        //{
        //    var result = _engine.UpdatePurchaseRecord(updated);
        //    return Ok(result);
        //}

        //// DELETE: api/PurchaseRecords/{id}
        //[ResponseType(typeof(string))]
        //public IHttpActionResult Delete(string id)
        //{
        //    var result = _engine.DeletePurchaseRecord(id);
        //    return Ok(result);
        //}
    }
}
