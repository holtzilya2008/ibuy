using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using IBuyServer.Models;

namespace IBuyServer.Logic.Mapping
{
    public class PurchasedItemMappingProfile : IMappingProfile<PurchasedItemDTO, PurchasedItem>
    {
        public PurchasedItem Map(PurchasedItemDTO model)
        {
            return new PurchasedItem
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Category = null
            };
        }

        public PurchasedItemDTO Map(PurchasedItem model)
        {
            return new PurchasedItemDTO
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
