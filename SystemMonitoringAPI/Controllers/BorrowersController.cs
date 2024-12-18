﻿using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("byDprid/{dprid}", Name = "GetDprid")]
        //public Borrowers GetDprid(int dprid)
        //{
        //    return _dataContext.Borrowers.SingleOrDefault(x => x.DprCode == dprid);
        //}
        [HttpGet("byDprnm{dprnm}", Name = "GetDprnm")]
        public Borrowers GetDprnm(string dprnm)
        {
            return _dataContext.Borrowers.SingleOrDefault(x => x.DprName == dprnm);
        }
        [HttpGet("dprnames")]
        public List<string> GetDprNames()
        {
            return _dataContext.Borrowers.Select(b => b.DprName).ToList();
        }

        //-------- Post Method
        [HttpPost("NewBor")]
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

        [HttpDelete("byBrwName{brwname}", Name = "DeleteByBrwName")]
        public void DeleteByBrwCode(string brwname)
        {
            var brw = _dataContext.Borrowers.FirstOrDefault(x => x.BrwName == brwname);
            if (brw != null)
            {
                _dataContext.Borrowers.Remove(brw);
                _dataContext.SaveChanges();
            }
        }
    }
}
