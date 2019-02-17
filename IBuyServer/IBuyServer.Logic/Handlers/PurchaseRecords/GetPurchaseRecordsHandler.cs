using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class GetPurchaseRecordsHandler : IHandler<Object, List<PurchaseRecordDTO>>
    {
        private IPurchaseRecordsRepository _repository;

        public GetPurchaseRecordsHandler(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public List<PurchaseRecordDTO> Handle(object requestArgs = null)
        {
            var mappingProfile = new PurchaseRecordMappingProfile();

            return _repository
                    .GetAll()
                    .Select(record => mappingProfile.ToDto(record))
                    .ToList();
        }
    }
}
