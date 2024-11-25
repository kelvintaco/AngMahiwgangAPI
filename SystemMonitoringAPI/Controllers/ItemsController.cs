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

        [HttpGet("{id}", Name = "Get")]
        public Items Get(int id)
        {
            return _dataContext.Items.SingleOrDefault(x => x.ItemCode == id);
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

    }
}