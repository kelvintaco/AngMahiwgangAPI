using Microsoft.AspNetCore.Mvc;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletedTransactionsController : Controller
    {
        private readonly DataContext _dataContext;

        public DeletedTransactionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public void Post([FromBody] DeletedTransactions deletedtransactions)
        {
            _dataContext.DeletedTransactions.Add(deletedtransactions);
            _dataContext.SaveChanges();
        }

        [HttpGet]
        public List<DeletedTransactions> Get()
        {
            return _dataContext.DeletedTransactions.ToList();
        }
    }
}
