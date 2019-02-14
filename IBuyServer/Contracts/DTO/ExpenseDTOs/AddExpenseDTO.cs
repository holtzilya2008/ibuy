using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO.ExpenseDTOs
{
    public class AddExpenseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PurchaseRecordId { get; set; }
    }
}
