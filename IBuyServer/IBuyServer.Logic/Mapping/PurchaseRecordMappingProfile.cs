using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Logic.Mapping
{
    class PurchaseRecordMappingProfile : IMappingProfile<PurchaseRecordDTO, PurchaseRecord>
    {
        public PurchaseRecordDTO ToDto(PurchaseRecord entity)
        {
            return new PurchaseRecordDTO
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public PurchaseRecord ToEntity(PurchaseRecordDTO dto)
        {
            return new PurchaseRecord
            {
                Id = Guid.Parse(dto.Id),
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
