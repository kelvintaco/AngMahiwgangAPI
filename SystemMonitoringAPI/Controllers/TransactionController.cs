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
                .Select(t => new Transactions
                {
                    ItemCode = t.ItemCode,
                    ItemName = t.Items.ItemName,
                    BrwCode = t.BrwCode,
                    BrwName = t.Borrowers.BrwName,
                    DprName = t.Borrowers.DprName,
                    TransID = t.TransID,
                    BorrowDate = t.BorrowDate,
                    Items = t.Items,
                    Borrowers = t.Borrowers
                })
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

        [HttpGet("transid")]
        public List<string> GetTransID()
        {
            return _dataContext.Transactions.Select(b => b.TransID).ToList();
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

        [HttpPost]
        public void Post([FromBody] Transactions transactions)
        {
            _dataContext.Transactions.Add(transactions);
            _dataContext.SaveChanges();
        }
        [HttpDelete("byTransId/{transId}", Name = "DeleteByTransId")]
        public void DeleteByTransId(string transId)
        {
            var trans = _dataContext.Transactions.FirstOrDefault(x => x.TransID == transId);
            if (trans != null)
            {
                _dataContext.Transactions.Remove(trans);
                _dataContext.SaveChanges();
            }
        }
    }
}
