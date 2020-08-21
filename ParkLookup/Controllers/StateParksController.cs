using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookup.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParkLookup.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StateParkController : ControllerBase
  {
    private ParkLookupContext _db;

    public StateParkController(ParkLookupContext db)
    {
      _db = db;
    }

    // GET http://localhost:5000/api/statepark
    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get()
    {
      return _db.StateParks.ToList();
    }

    // POST http://localhost:5000/api/statepark
    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    
    [HttpGet("{id}")]
    public ActionResult<StatePark> Get(int id)
    {
        return _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
        statePark.StateParkId = id;
        _db.Entry(statePark).State = EntityState.Modified;
        _db.SaveChanges();
    }
  }
}