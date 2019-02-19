using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DTO.ExpenseDTOs;
using IBuyServer.Domain.DataModel.Repositories;
using IBuyServer.Infrastructure.MediatR;
using IBuyServer.Logic.Mapping.ExpenseProfiles;
using MediatR;

namespace IBuyServer.Logic.Handlers.ExpenseHandlers
{
    public class GetExpensesForPurchaseRecordHandler : IRequestHandler<GetExpensesForPurchaseRecordRequest, Response<List<ExpenseDTO>>>
    {
        private IExpenseRepository _repository;

        public GetExpensesForPurchaseRecordHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<ExpenseDTO>>> Handle(GetExpensesForPurchaseRecordRequest request, CancellationToken cancellationToken)
        {
            var expenseMappingProfile = new ExpenseMappingProfile();
            var expenses = await _repository.GetAll((expense) => expense.PurchaseRecordId == request.PurchaseRecordId);
            var result = expenses.Select((expense) => expenseMappingProfile.ToDto(expense)).ToList();
            return new Response<List<ExpenseDTO>>(result);
        }
    }

    public class GetExpensesForPurchaseRecordRequest : IRequest<Response<List<ExpenseDTO>>>
    {
        public Guid PurchaseRecordId { get; }

        public GetExpensesForPurchaseRecordRequest(string purchaseRecordId)
        {
            PurchaseRecordId = Guid.Parse(purchaseRecordId);
        }

        public GetExpensesForPurchaseRecordRequest(Guid purchaseRecordId)
        {
            PurchaseRecordId = purchaseRecordId;
        }
    }
}
