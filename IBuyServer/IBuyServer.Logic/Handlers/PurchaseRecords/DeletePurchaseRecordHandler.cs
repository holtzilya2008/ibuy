using System;
using IBuyServer.Domain.DataModel.Repositories;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class DeletePurchaseRecordHandler : IHandler<string, string>
    {
        private IPurchaseRecordsRepository _repository;

        public DeletePurchaseRecordHandler(IPurchaseRecordsRepository repository)
        {
            _repository = repository;
        }

        public string Handle(string requestArgs)
        {
            Guid id = Guid.Parse(requestArgs);
            return _repository.Delete(id).ToString();
        }
    }
}
