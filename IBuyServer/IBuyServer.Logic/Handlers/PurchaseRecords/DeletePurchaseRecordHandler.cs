using System;
using System.Threading;
using System.Threading.Tasks;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.MediatR;
using MediatR;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class DeletePurchaseRecordHandler: IRequestHandler<DeletePurchaseRecordRequest, Response<string>>
    {
        private IPurchaseRecordsRepository _repository;

        public DeletePurchaseRecordHandler(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<string>> Handle(DeletePurchaseRecordRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(request.Id);
            var result = await _repository.Delete(id);
            return new Response<string>(result.ToString());
        }
    }

    public class DeletePurchaseRecordRequest : IRequest<Response<string>>
    {
        public string Id { get; }

        public DeletePurchaseRecordRequest(string id)
        {
            Id = id;
        }
    }
}
