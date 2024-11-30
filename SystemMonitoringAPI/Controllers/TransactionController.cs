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
        [HttpPost]
        public IActionResult CreateTransaction([FromBody] Transactions request)
        {
            // Find the item by ItemName
            var item = _dataContext.Items.FirstOrDefault(i => i.ItemName == request.ItemName);

            if (item == null)
            {
                return NotFound("Item not found");
            }

            // Create a new transaction
            var transaction = new Transactions
            {
                ItemCode = item.ItemCode,
                BrwCode = Guid.NewGuid().ToString(), // Generate a new BrwCode
                TransID = Guid.NewGuid().ToString(), // Generate a new TransId
                BorrowDate = request.BorrowDate,
            };

            // Add the transaction to the database
            _dataContext.Transactions.Add(transaction);
            _dataContext.SaveChanges();

            return Ok(new { message = "Transaction created successfully" });
        }
    }
}
