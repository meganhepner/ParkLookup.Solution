using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkLookup.Models;

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

    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get()
    {
      return _db.StateParks.ToList();
    }

    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }
  }
}