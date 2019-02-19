
using System.Threading;
using System.Threading.Tasks;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.MediatR;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;
using MediatR;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class UpdatePurchaseRecord: IRequestHandler<UpdatePurchaseRecordRequest, Response<PurchaseRecordDTO>>
    {
        private IPurchaseRecordsRepository _repository;

        public UpdatePurchaseRecord(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<PurchaseRecordDTO>> Handle(UpdatePurchaseRecordRequest request, CancellationToken cancellationToken)
        {
            var mappingProfile = new PurchaseRecordMappingProfile();
            var updated = await _repository.Update(mappingProfile.ToEntity(request.RequestDTO));
            return new Response<PurchaseRecordDTO>(mappingProfile.ToDto(updated));
        }
    }

    public class UpdatePurchaseRecordRequest : IRequest<Response<PurchaseRecordDTO>>
    {
        public PurchaseRecordDTO RequestDTO { get; }

        public UpdatePurchaseRecordRequest(PurchaseRecordDTO requestDTO)
        {
            RequestDTO = requestDTO;
        }
    }
}
