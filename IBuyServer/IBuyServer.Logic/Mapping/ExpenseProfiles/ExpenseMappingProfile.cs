using System;
using Contracts.DTO.ExpenseDTOs;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Logic.Mapping.ExpenseProfiles
{
    public class ExpenseMappingProfile : IMappingProfile<ExpenseDTO, Expense>
    {
        public ExpenseDTO ToDto(Expense entity)
        {
            return new ExpenseDTO()
            {
                Id = entity.Id.ToString(),
                Description = entity.Description,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public Expense ToEntity(ExpenseDTO dto)
        {
            return new Expense()
            {
                Id = Guid.Parse(dto.Id),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };
        }
    }
}
