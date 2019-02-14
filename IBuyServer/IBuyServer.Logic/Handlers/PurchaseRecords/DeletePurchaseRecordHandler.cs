using System;
using IBuyServer.Domain.DataModel.Repositories;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    public class DeletePurchaseRecordHandler : IHandler<string, string>
    {
        public string Handle(string requestArgs)
        {
            var repository = new PurchaseRecordsRepository();
            Guid id = Guid.Parse(requestArgs);
            return repository.Delete(id).ToString();
        }
    }
}
