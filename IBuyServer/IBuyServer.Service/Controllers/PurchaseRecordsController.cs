
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

        // GET: api/PurchaseRecords/{id}
        [ResponseType(typeof(PurchaseRecordDTO[]))]
        public async Task<IHttpActionResult> Get(string id)
        {
            var result = await _mediator.Send(new GetPurchaseRecordByIdRequest(id));
            return Ok(result.Value);
        }

        // POST: api/PurchaseRecords
        [ResponseType(typeof(PurchaseRecordDTO))]
        public async Task<IHttpActionResult> Create([FromBody] AddPurchaseRecordDTO newRecord)
        {
            var result = await _mediator.Send(new AddPurchaseRecordRequest(newRecord));
            return Ok(result.Value);
        }

        // PUT: api/PurchaseRecords/
        [ResponseType(typeof(PurchaseRecordDTO))]
        public async Task<IHttpActionResult> Update([FromBody] PurchaseRecordDTO updated)
        {
            var result = await _mediator.Send(new UpdatePurchaseRecordRequest(updated));
            return Ok(result.Value);
        }

        // DELETE: api/PurchaseRecords/{id}
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeletePurchaseRecordRequest(id));
            return Ok(result.Value);
        }
    }
}
