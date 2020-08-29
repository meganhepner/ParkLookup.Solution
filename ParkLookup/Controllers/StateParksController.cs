using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkLookup.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StateParksController : ControllerBase
  {
    private ParkLookupContext _db;

    public StateParksController(ParkLookupContext db)
    {
      _db = db;
    }

    [HttpGet] //PAGINATION PART 1
    public ActionResult<IEnumerable<StatePark>> Get([FromQuery] PaginationFilter filter, string name, string state, string surprise)
    {
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var pagedData = _db.StateParks.ToList()
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToList();
      var totalRecords = _db.StateParks.Count();
      var query = _db.StateParks.AsQueryable();
      if (name != null || state != null || surprise != null)
      {
        if (name !=null)
        {
          query = query.Where(entry => entry.StateParkName.Contains(name));
        }
        if (state !=null)
        {
          query = query.Where(entry => entry.StateParkState.Contains(state));
        }
        if (surprise !=null)
        {
          Random rnd = new Random();
          var allParks = _db.StateParks.ToArray();
          int index = rnd.Next(allParks.Length-1);
          query = query.Where(entry => entry.StateParkId == index);

        }
        return query.ToList();
      }
      else
      {
        return Ok(new PagedResponse<List<StatePark>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
      }
    }

    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    [HttpGet("{id}")] // PAGINATION PART 2
    public ActionResult<StatePark> Get(int id)
    {
        var statePark =  _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
        return Ok(new Response<StatePark>(statePark));
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
        statePark.StateParkId = id;
        _db.Entry(statePark).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var stateParkToDelete = _db.StateParks.FirstOrDefault(entry => entry.StateParkId == id);
      _db.StateParks.Remove(stateParkToDelete);
      _db.SaveChanges();
    }
  } 
}