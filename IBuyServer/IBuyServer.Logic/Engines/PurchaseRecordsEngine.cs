using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Domain.Models.Entities;
using IBuyServer.Infrastructure.DataAccess;
using IBuyServer.Logic.Handlers.PurchaseRecords;

namespace IBuyServer.Logic.Engines
{
    public class PurchaseRecordsEngine: IPurchaseRecordsEngine
    {
        private IPurchaseRecordsRepository _repository;

        public PurchaseRecordsEngine(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public List<PurchaseRecordDTO> GetAllPurchaseRecords()
        {
            return new GetPurchaseRecordsHandler(_repository).Handle();
        }

        public PurchaseRecordDetailsDTO GetPurchaseRecordDetails(string id)
        {
            return new GetPurchaseRecordById(_repository).Handle(id);
        }

        public PurchaseRecordDTO AddPurchaseRecord(AddPurchaseRecordDTO newRecord)
        {
            return new AddPurchaseRecordHandler(_repository).Handle(newRecord);
        }

        public PurchaseRecordDTO UpdatePurchaseRecord(PurchaseRecordDTO updatedRecord)
        {
            return new UpdatePurchaseRecord(_repository).Handle(updatedRecord);
        }

        public string DeletePurchaseRecord(string id)
        {
            return new DeletePurchaseRecordHandler(_repository).Handle(id);
        }
    }
}
