using Microsoft.AspNetCore.Mvc;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ItemsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //--------- Get Method 
        [HttpGet]
        public IEnumerable<Items> Get()
        {
            return _dataContext.Items;
        }
        [HttpGet("itemnames")]
        public List<string> GetItemNames()
        {
            return _dataContext.Items.Select(i => i.ItemName).ToList();
        }

        [HttpGet("{id}", Name = "Get")]
        public Items Get(int id)
        {
            return _dataContext.Items.SingleOrDefault(x => x.ItemCode == id);
        }

        [HttpGet("byIsOnBorrowed/{isborrow}", Name = "GetIsOnBorrow")]
        public Items GetIsOnBorrow(int isborrow)
        {
            return _dataContext.Items.SingleOrDefault(x => x.onBorrow == isborrow);
        }

        [HttpGet("byIsNotOnBorrow/{isnotonborrow}", Name = "GetIsNotOnBorrow")]
        public Items GetIsNotOnBorrow(int isnotonborrow)
        {
            return _dataContext.Items.SingleOrDefault(x => x.isnotonBorrow == isnotonborrow);
        }

        //-------- Post Method
        [HttpPost]
        public void Post([FromBody] Items item)
        {
            _dataContext.Items.Add(item);
            _dataContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Items item)
        {
            _dataContext.Items.Update(item);
            _dataContext.SaveChanges();
        }

        [HttpPut("byItemCode/{itemCode}", Name = "UpdateBorrowStatus")]
        public void UpdateBorrowStatus(int itemCode, [FromBody] Items itemcode)
        {
            // Find the item by ItemCode
            var item = _dataContext.Items.FirstOrDefault(i => i.ItemCode == itemCode);

            // Update the onBorrow and isnotonBorrow fields
            item.onBorrow = itemcode.onBorrow;
            item.isnotonBorrow = itemcode.isnotonBorrow;

            // Save changes to the database
            _dataContext.SaveChanges();
        }

    }
}