using Contracts.DTO.ExpenseDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Logic.Mapping.ExpenseProfiles;

namespace IBuyServer.Logic.Handlers.ExpenseHandlers
{
    //public class AddExpenseHandler : IHandler<AddExpenseDTO, ExpenseDTO>
    //{
    //    public ExpenseDTO Handle(AddExpenseDTO requestArgs)
    //    {
    //        var expenseMappingProfile = new ExpenseMappingProfile();
    //        var addExpenseMappinProfile = new AddExpenseMappingProfile();
    //        var repository = new ExpensesRepository();

    //        var addedEntity = repository.Add(addExpenseMappinProfile.ToEntity(requestArgs));
    //        return expenseMappingProfile.ToDto(addedEntity);
    //    }
    //}
}
