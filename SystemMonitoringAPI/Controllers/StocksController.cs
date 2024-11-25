using Microsoft.AspNetCore.Mvc;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private readonly DataContext _dataContext;
        public StocksController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //--------- Get Method 
        [HttpGet]
        public IEnumerable<Stocks> Get()
        {
            return _dataContext.Stocks;
        }

        [HttpGet("byIsOnBorrowed/{isborrow}", Name = "GetIsOnBorrow")]
        public Stocks GetIsOnBorrow(int isborrow)
        {
            return _dataContext.Stocks.SingleOrDefault(x => x.onBorrow == isborrow);
        }
        [HttpGet("byIsNotOnBorrow/{isnotonborrow}", Name = "GetIsNotOnBorrow")]
        public Stocks GetIsNotOnBorrow(int isnotonborrow)
        {
            return _dataContext.Stocks.SingleOrDefault(x => x.isnotonBorrow == isnotonborrow);
        }
    }
}
