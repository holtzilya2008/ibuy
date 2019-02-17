using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.DTO.PurchaseRecordDTOs;

namespace IBuyServer.Logic.Engines
{
    public interface IPurchaseRecordsEngine
    {
        List<PurchaseRecordDTO> GetAllPurchaseRecords();
        PurchaseRecordDetailsDTO GetPurchaseRecordDetails(string id);
        PurchaseRecordDTO AddPurchaseRecord(AddPurchaseRecordDTO newRecord);
        PurchaseRecordDTO UpdatePurchaseRecord(PurchaseRecordDTO updatedRecord);
        string DeletePurchaseRecord(string id);
    }
}
