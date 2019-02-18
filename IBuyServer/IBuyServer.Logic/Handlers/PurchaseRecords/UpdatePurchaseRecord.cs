
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    //public class UpdatePurchaseRecord : IHandler<PurchaseRecordDTO, PurchaseRecordDTO>
    //{
    //    private IPurchaseRecordsRepository _repository;

    //    public UpdatePurchaseRecord(IPurchaseRecordsRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public PurchaseRecordDTO Handle(PurchaseRecordDTO requestArgs)
    //    {
    //        var mappingProfile = new PurchaseRecordMappingProfile();

    //        var updated = _repository.Update(mappingProfile.ToEntity(requestArgs));
    //        return mappingProfile.ToDto(updated);
    //    }
    //}
}
