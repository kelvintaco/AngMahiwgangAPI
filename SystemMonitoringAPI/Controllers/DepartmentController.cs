using Microsoft.AspNetCore.Mvc;
using SystemMonitoringAPI.Context;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public DepartmentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //--------- Get Method 
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _dataContext.Departments;
        }

        [HttpGet("byDprid/{dprid}", Name = "GetDprid")]
        public Department Get(int dprid)
        {
            return _dataContext.Departments.SingleOrDefault(x => x.DprCode == dprid);
        }
        [HttpGet("byDprnm{dprnm}", Name = "GetDprnm")]
        public Department Get(string dprnm)
        {
            return _dataContext.Departments.SingleOrDefault(x => x.DprName == dprnm);
        }
    }
}
