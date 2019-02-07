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
    public class GetPurchaseRecordById : IHandler<string, PurchaseRecordDTO>
    {
        public PurchaseRecordDTO Handle(string requestArgs)
        {
            var repository = new PurchaseRecordsRepository();
            var mappingProfile = new PurchaseRecordMappingProfile();
            Guid id = Guid.Parse(requestArgs);

            var record = repository.Get(id);
            return mappingProfile.ToDto(record);
        }
    }
}
