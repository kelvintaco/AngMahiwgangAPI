using Microsoft.AspNetCore.Mvc;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public BorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //--------- Get Method 
        [HttpGet]
        public IEnumerable<Borrowers> Get()
        {
            return _dataContext.Borrowers;
        }

        [HttpGet("byBrwCode{brwid}", Name = "GetByBrwCode")]
        public Borrowers GetByBrwCode(string brwid)
        {
            return _dataContext.Borrowers.SingleOrDefault(x => x.BrwCode == brwid);
        }

        //-------- Post Method
        [HttpPost]
        public void Post([FromBody] Borrowers borrowers)
        {
            _dataContext.Borrowers.Add(borrowers);
            _dataContext.SaveChanges();
        }

        [HttpPut("byBrwCode{brwid}", Name = "PutByBrwCode")]
        public void PutByBrwCode([FromBody] Borrowers borrowers)
        {
            _dataContext.Borrowers.Update(borrowers);
            _dataContext.SaveChanges();
        }

        [HttpDelete("byBrwCode{brwid}", Name = "DeleteByBrwCode")]
        public void DeleteByBrwCode(string brwid)
        {
            var brw = _dataContext.Borrowers.FirstOrDefault(x => x.BrwCode == brwid);
            if (brw != null)
            {
                _dataContext.Borrowers.Remove(brw);
                _dataContext.SaveChanges();
            }
        }
    }
}
