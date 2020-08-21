using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkLookup.Models;

namespace ParkLookup.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NationalParkController : ControllerBase
  {
    private ParkLookupContext _db;

    public NationalParkController(ParkLookupContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<NationalPark>> Get()
    {
      return _db.NationalParks.ToList();
    }

    [HttpPost]
    public void Post([FromBody] NationalPark nationalPark)
    {
      _db.NationalParks.Add(nationalPark);
      _db.SaveChanges();
    }
  }
}