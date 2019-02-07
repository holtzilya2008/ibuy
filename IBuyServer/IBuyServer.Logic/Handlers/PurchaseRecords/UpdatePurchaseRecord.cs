using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class UpdatePurchaseRecord : IHandler<PurchaseRecordDTO, PurchaseRecordDTO>
    {
        public PurchaseRecordDTO Handle(PurchaseRecordDTO requestArgs)
        {
            var mappingProfile = new PurchaseRecordMappingProfile();
            var repository = new PurchaseRecordsRepository();

            var updated = repository.Update(mappingProfile.ToEntity(requestArgs));
            return mappingProfile.ToDto(updated);
        }
    }
}
