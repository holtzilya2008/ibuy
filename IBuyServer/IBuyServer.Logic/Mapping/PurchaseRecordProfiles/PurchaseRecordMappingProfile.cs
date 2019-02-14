using System;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Logic.Mapping.PurchaseRecordProfiles
{
    class PurchaseRecordMappingProfile : IMappingProfile<PurchaseRecordDTO, PurchaseRecord>
    {
        public PurchaseRecordDTO ToDto(PurchaseRecord entity)
        {
            return new PurchaseRecordDTO
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };
        }

        public PurchaseRecord ToEntity(PurchaseRecordDTO dto)
        {
            return new PurchaseRecord
            {
                Id = Guid.Parse(dto.Id),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };
        }
    }
}
