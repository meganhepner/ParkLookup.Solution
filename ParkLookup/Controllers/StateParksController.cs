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
    // http://localhost:5000/api/nationalpark/?pageNumber=2&pageSize=1
    [HttpGet] //PAGINATION PART 1
    public ActionResult<IEnumerable<StatePark>> Get([FromQuery] PaginationFilter filter)
    {
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var pagedData = _db.StateParks.ToList()
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToList();
      var totalRecords = _db.StateParks.Count();
      return Ok(new PagedResponse<List<StatePark>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
    }

    // POST http://localhost:5000/api/statepark
    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    // GET http://localhost:5000/api/statepark/5
    [HttpGet("{id}")] // PAGINATION PART 2
    public ActionResult<StatePark> Get(int id)
    {
        var statePark =  _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
        return Ok(new Response<StatePark>(statePark));
    }

    // POST http://localhost:5000/api/statepark/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
        statePark.StateParkId = id;
        _db.Entry(statePark).State = EntityState.Modified;
        _db.SaveChanges();
    }

    // DELETE http://localhost:5000/api/statepark/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var stateParkToDelete = _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
      _db.StateParks.Remove(stateParkToDelete);
      _db.SaveChanges();
    }
  } 
}