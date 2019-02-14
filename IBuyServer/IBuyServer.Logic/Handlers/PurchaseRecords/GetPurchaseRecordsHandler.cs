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
        public List<PurchaseRecordDTO> Handle(object requestArgs)
        {
            var mappingProfile = new PurchaseRecordMappingProfile();
            var repository = new PurchaseRecordsRepository();

            return repository
                    .GetAll()
                    .Select(record => mappingProfile.ToDto(record))
                    .ToList();
        }
    }
}
