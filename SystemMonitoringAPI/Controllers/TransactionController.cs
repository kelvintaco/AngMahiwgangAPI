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
        public IActionResult CreateTransaction([FromBody] TransactionRequest request)
        {
            var transaction = new Transactions
            {
                ItemCode = GenerateItemCode(),
                BrwCode = GenerateBrwCode(),
                TransID = GenerateTransId(),
                BorrowDate = DateOnly.FromDateTime(DateTime.Now),
                Items = _dataContext.Items.Find(request.ItemId),
                Borrowers = _dataContext.Borrowers.Find(request.BorrowerName)
            };

            _dataContext.Transactions.Add(transaction);
            _dataContext.SaveChanges(); //error create the module enter borrower details first -> enter item to borrow -> then store it into the transaction table

            return CreatedAtAction(nameof(Get), new { id = transaction.ItemCode }, transaction);
        }

        private int GenerateItemCode()
        {
            return _dataContext.Transactions.Max(t => t.ItemCode) + 1;
        }

        private string GenerateBrwCode()
        {
            int brwCodeNumber = int.Parse(_dataContext.Transactions.Max(t => t.BrwCode.Substring(3))) + 1;
            return $"BRW{brwCodeNumber:D2}";
        }

        private string GenerateTransId()
        {
            string lastTransId = _dataContext.Transactions.Max(t => t.TransID);
            int transIdNumber = int.Parse(lastTransId.Replace("TR", "")) + 1;
            return $"TR{transIdNumber:D3}";
        }
    }
}
