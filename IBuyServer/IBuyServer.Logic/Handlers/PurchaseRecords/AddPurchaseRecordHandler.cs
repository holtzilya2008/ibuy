using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class AddPurchaseRecordHandler : IHandler<AddPurchaseRecordDTO, PurchaseRecordDTO>
    {
        public PurchaseRecordDTO Handle(AddPurchaseRecordDTO requestArgs)
        {
            var purchaseRecordMappingProfile = new PurchaseRecordMappingProfile();
            var addPurchaseRecordMappingProfile = new AddPurchaseRecordMappingProfile();
            var repository = new PurchaseRecordsRepository();

            var addedEntity = repository.Add(addPurchaseRecordMappingProfile.ToEntity(requestArgs));
            return purchaseRecordMappingProfile.ToDto(addedEntity);
        }
    }
}
