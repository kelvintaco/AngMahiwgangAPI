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
        [HttpGet("item-index")]
        public IActionResult ItemIndex()
        {
            var itemtransactions = _dataContext.Transactions.Include(x => x.Items).ToList();
            return View(itemtransactions);
        }
        [HttpGet("bor-index")]
        public IActionResult BorIndex()
        {
            var bortransactions = _dataContext.Transactions.Include(x => x.Borrowers).ToList();
            return View(bortransactions);
        }

        //--------- Get All Transactions
        [HttpGet]
        public List<Transactions> Get()
        {
            return _dataContext.Transactions
                .Include(t => t.Items)
                .Include(t => t.Borrowers)
                .ToList();
        }

        //--------- Get Transaction by ItemCode
        [HttpGet("byItemCode/{itmcode}", Name = "GetItemCode")]
        public List<Transactions> GetItemCode(int itmcode)
        {
            return _dataContext.Transactions
                .Include(t => t.Items)
                .Include(t => t.Borrowers)
                .Where(x => x.ItemCode == itmcode)
                .ToList();

        }

        //--------- Get Transaction by BrwCode
        [HttpGet("byBrwCode/{brwcode}", Name = "GetBrwCode")]
        public List<Transactions> GetBrwCode(string brwcode)
        {
            return _dataContext.Transactions
                .Include(t => t.Items)
                .Include(t => t.Borrowers)
                .Where(x => x.BrwCode == brwcode)
                .ToList();
        }
    }
}
