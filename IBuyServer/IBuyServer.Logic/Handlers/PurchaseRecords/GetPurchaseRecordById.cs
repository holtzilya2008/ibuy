using System;
using System.Linq;
using System.Runtime.InteropServices;
using Contracts.DTO.ExpenseDTOs;
using Contracts.DTO.PurchaseRecordDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.ExpenseProfiles;
using IBuyServer.Logic.Mapping.PurchaseRecordProfiles;

namespace IBuyServer.Logic.Handlers.PurchaseRecords
{
    //public class GetPurchaseRecordById : IHandler<string, PurchaseRecordDetailsDTO>
    //{
    //    private IPurchaseRecordsRepository _repository;

    //    public GetPurchaseRecordById(IPurchaseRecordsRepository repository)
    //    {
    //        _repository = repository;   
    //    }

    //    public PurchaseRecordDetailsDTO Handle(string requestArgs)
    //    {
    //        var expenseRepository = new ExpensesRepository();
    //        var expenseMappingProfile = new ExpenseMappingProfile();
    //        Guid id = Guid.Parse(requestArgs);

    //        var record = _repository.GetById(id);
    //        var expenses = expenseRepository.GetAll((expense) => expense.PurchaseRecordId == id );
    //        return new PurchaseRecordDetailsDTO()
    //        {
    //            Id = record.Id.ToString(),
    //            Name = record.Name,
    //            Description = record.Description,
    //            Price = record.Price,
    //            RelatedExpenses = expenses.Select((expense) => expenseMappingProfile.ToDto(expense))
    //                .ToList<ExpenseDTO>()
    //        };
    //    }
    //}
}
