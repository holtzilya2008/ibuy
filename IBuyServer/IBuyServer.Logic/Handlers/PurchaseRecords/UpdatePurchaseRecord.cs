
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;

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
