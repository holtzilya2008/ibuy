using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class AddPurchaseRecordHandler : IHandler<AddPurchaseRecordDTO, PurchaseRecordDTO>
    {

        private IPurchaseRecordsRepository _repository;

        public AddPurchaseRecordHandler(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public PurchaseRecordDTO Handle(AddPurchaseRecordDTO requestArgs)
        {
            var purchaseRecordMappingProfile = new PurchaseRecordMappingProfile();
            var addPurchaseRecordMappingProfile = new AddPurchaseRecordMappingProfile();

            var addedEntity = _repository.Add(addPurchaseRecordMappingProfile.ToEntity(requestArgs));
            return purchaseRecordMappingProfile.ToDto(addedEntity);
        }
    }
}
