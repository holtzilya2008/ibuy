using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts.DTO.ExpenseDTOs;
using IBuyServer.Domain.Models.Entities;

namespace IBuyServer.Logic.Mapping.ExpenseProfiles
{
    public class AddExpenseMappingProfile: IMappingProfile<AddExpenseDTO, Expense>
    {
        public AddExpenseDTO ToDto(Expense entity)
        {
            return new AddExpenseDTO()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                PurchaseRecordId = entity.PurchaseRecordId.ToString()
            };
        }

        public Expense ToEntity(AddExpenseDTO dto)
        {
            return new Expense()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                PurchaseRecordId = Guid.Parse(dto.PurchaseRecordId)
            };
        }
    }
}
