using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using IBuyServer.Domain.DataModel.Context;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class GetPurchaseRecordsHandler : IHandler<Object, List<PurchaseRecordDTO>>
    {
        public List<PurchaseRecordDTO> Handle(object requestArgs)
        {
            var mappingProfile = new PurchaseRecordMappingProfile();
            var repository = new PurchaseRecordsRepository();

            return repository
                    .All()
                    .Select(record => mappingProfile.ToDto(record))
                    .ToList();
        }
    }
}
