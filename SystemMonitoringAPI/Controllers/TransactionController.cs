using Microsoft.AspNetCore.Mvc;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SystemMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly DataContext _dataContext;

        public TransactionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //--------- Get All Transactions
        [HttpGet]
        public IEnumerable<Transactions> Get()
        {
            return _dataContext.Transactions
                .Include(t => t.Items) // Include related Items data
                .Include(t => t.Borrowers) // Include related Borrowers data
                .ToList();
        }

        //--------- Get Transaction by ItemCode
        [HttpGet("byItemCode/{itmcode}", Name = "GetItemCode")]
        public Transactions GetItemCode(int itmcode)
        {
            return _dataContext.Transactions
                .Include(t => t.Items)
                .Include(t => t.Borrowers)
                .SingleOrDefault(x => x.ItemCode == itmcode);
        }

        //--------- Get Transaction by BrwCode
        [HttpGet("byBrwCode/{brwcode}", Name = "GetBrwCode")]
        public Transactions GetBrwCode(string brwcode)
        {
            return _dataContext.Transactions
                .Include(t => t.Items)
                .Include(t => t.Borrowers)
                .SingleOrDefault(x => x.BrwCode == brwcode);
        }
    }
}
