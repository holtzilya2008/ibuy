using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DTO.ExpenseDTOs;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.MediatR;
using IBuyServer.Logic.Handlers.ExpenseHandlers;
using IBuyServer.Logic.Mapping.ExpenseProfiles;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;
using MediatR;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class GetPurchaseRecordById : IRequestHandler<GetPurchaseRecordByIdRequest, Response<PurchaseRecordDetailsDTO>>
    {
        private IPurchaseRecordsRepository _repository;
        private IMediator _mediator;

        public GetPurchaseRecordById(IPurchaseRecordsRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Response<PurchaseRecordDetailsDTO>> Handle(GetPurchaseRecordByIdRequest request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetById(request.Id);
            var expenses = (await _mediator.Send(new GetExpensesForPurchaseRecordRequest(request.Id))).Value;
            var result = new PurchaseRecordDetailsDTO()
            {
                Id = record.Id.ToString(),
                Name = record.Name,
                Description = record.Description,
                Price = record.Price,
                RelatedExpenses = expenses
            };
            return new Response<PurchaseRecordDetailsDTO>(result);
        }
    }

    public class GetPurchaseRecordByIdRequest : IRequest<Response<PurchaseRecordDetailsDTO>>
    {
        public Guid Id { get; }

        public GetPurchaseRecordByIdRequest(string id)
        {
            Id = Guid.Parse(id);
        }
    }
}
