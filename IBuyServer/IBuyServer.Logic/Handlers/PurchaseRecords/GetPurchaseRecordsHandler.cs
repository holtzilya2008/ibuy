using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.MediatR;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;
using MediatR;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class GetPurchaseRecordsHandler : IRequestHandler<GetPurchaseRecordsRequest, Response<List<PurchaseRecordDTO>>>
    {
        private readonly IPurchaseRecordsRepository _repository;

        public GetPurchaseRecordsHandler(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<PurchaseRecordDTO>>> Handle(GetPurchaseRecordsRequest request, CancellationToken cancellationToken)
        {
            var mappingProfile = new PurchaseRecordMappingProfile();
            var purchaseRecordsList = await _repository.GetAll();
            var dtoList = purchaseRecordsList.Select(record => mappingProfile.ToDto(record)).ToList();
            return new Response<List<PurchaseRecordDTO>>(dtoList);
        }
    }

    public class GetPurchaseRecordsRequest: IRequest<Response<List<PurchaseRecordDTO>>>
    {
        public GetPurchaseRecordsRequest()
        {
        }
    }
}
