using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Logic.Mapping
{
    public class AddPurchaseRecordMappingProfile : IMappingProfile<AddPurchaseRecordDTO, PurchaseRecord>
    {
        public AddPurchaseRecordDTO ToDto(PurchaseRecord entity)
        {
            return new AddPurchaseRecordDTO()
            {
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public PurchaseRecord ToEntity(AddPurchaseRecordDTO dto)
        {
            return new PurchaseRecord()
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
