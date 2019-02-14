using IBuyServer.Domain.DataModel.Context;
using IBuyServer.Domain.Models.Entities;
using IBuyServer.Infrastructure.DataAccess;

namespace IBuyServer.Domain.DataModel.Repositories
{
    public class ExpensesRepository : EntityRepositoryBase<Expense, IBuyContext>
    {
        public ExpensesRepository() : base(new IBuyContext())
        {
        }
    }
}
