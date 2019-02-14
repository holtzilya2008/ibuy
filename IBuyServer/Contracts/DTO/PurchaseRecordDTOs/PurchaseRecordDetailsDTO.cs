using System.Collections.Generic;
using Contracts.DTO.ExpenseDTOs;

namespace Contracts.DTO.PurchaseRecordDTOs
{
    public class PurchaseRecordDetailsDTO : PurchaseRecordDTO
    {
        public List<ExpenseDTO> RelatedExpenses { get; set; }
    }
}