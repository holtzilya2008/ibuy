using System.Threading;
using System.Threading.Tasks;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.MediatR;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;
using MediatR;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class AddPurchaseRecordHandler : IRequestHandler<AddPurchaseRecordRequest, Response<PurchaseRecordDTO>>
    {
        private IPurchaseRecordsRepository _repository;

        public AddPurchaseRecordHandler(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<PurchaseRecordDTO>> Handle(AddPurchaseRecordRequest request, CancellationToken cancellationToken)
        {
            var purchaseRecordMappingProfile = new PurchaseRecordMappingProfile();
            var addPurchaseRecordMappingProfile = new AddPurchaseRecordMappingProfile();
            var addedEntity = await _repository.Add(addPurchaseRecordMappingProfile.ToEntity(request.RequestDTO));
            return new Response<PurchaseRecordDTO>(purchaseRecordMappingProfile.ToDto(addedEntity));
        }
    }

    public class AddPurchaseRecordRequest : IRequest<Response<PurchaseRecordDTO>>
    {
        public AddPurchaseRecordDTO RequestDTO { get; set; }

        public AddPurchaseRecordRequest(AddPurchaseRecordDTO addPurchaseRecordDTO)
        {
            RequestDTO = addPurchaseRecordDTO;
        }
    }
}
