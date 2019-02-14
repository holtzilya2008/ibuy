using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Logic.Mapping.PurchaseRecordProfiles
{
    public class AddPurchaseRecordMappingProfile : IMappingProfile<AddPurchaseRecordDTO, PurchaseRecord>
    {
        public AddPurchaseRecordDTO ToDto(PurchaseRecord entity)
        {
            return new AddPurchaseRecordDTO()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };
        }

        public PurchaseRecord ToEntity(AddPurchaseRecordDTO dto)
        {
            return new PurchaseRecord()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };
        }
    }
}
