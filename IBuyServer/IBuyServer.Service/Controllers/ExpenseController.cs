using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Contracts.DTO.ExpenseDTOs;
using IBuyServer.Logic.Handlers.ExpenseHandlers;

namespace IBuyServer.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExpenseController : ApiController
    {
        // POST: api/Expense
        [ResponseType(typeof(ExpenseDTO))]
        public IHttpActionResult Post([FromBody] AddExpenseDTO newRecord)
        {
            var result = new AddExpenseHandler().Handle(newRecord);
            return Ok(result);
        }

        // DELETE: api/Expense/{id}
        [ResponseType(typeof(string))]
        public IHttpActionResult Delete(string id)
        {
            var result = new DeleteExpenseHandler().Handle(id);
            return Ok(result);
        }
    }
}
