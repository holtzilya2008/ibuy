using Contracts.DTO.PurchaseRecord;

namespace IBuyServer.Logic.Mapping.PurchaseRecord
{
    public class AddPurchaseRecordMappingProfile : IMappingProfile<AddPurchaseRecordDTO, Domain.Models.Entities.PurchaseRecord>
    {
        public AddPurchaseRecordDTO ToDto(Domain.Models.Entities.PurchaseRecord entity)
        {
            return new AddPurchaseRecordDTO()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };
        }

        public Domain.Models.Entities.PurchaseRecord ToEntity(AddPurchaseRecordDTO dto)
        {
            return new Domain.Models.Entities.PurchaseRecord()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };
        }
    }
}
