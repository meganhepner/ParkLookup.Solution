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
  public class NationalParksController : ControllerBase
  {
    private ParkLookupContext _db;

    public NationalParksController(ParkLookupContext db)
    {
      _db = db;
    }

    [HttpGet] //PAGINATION PART 1
    public ActionResult<IEnumerable<NationalPark>> Get([FromQuery] PaginationFilter filter, string name, string state, string surprise)
    {
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var pagedData = _db.NationalParks.ToList()
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToList();
      var totalRecords = _db.NationalParks.Count();
      var query = _db.NationalParks.AsQueryable();
      if (name != null || state != null || surprise != null)
      {
        if (name !=null)
        {
          query = query.Where(entry => entry.NationalParkName.Contains(name));
        }
        if (state !=null)
        {
          query = query.Where(entry => entry.NationalParkState.Contains(state));
        }
        if (surprise !=null)
        {
          Random rnd = new Random();
          var allParks = _db.NationalParks.ToArray();
          int index = rnd.Next(allParks.Length-1);
          query = query.Where(entry => entry.NationalParkId == index);
        }
        return query.ToList();
      }
      else
      {
        return Ok(new PagedResponse<List<NationalPark>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
      }
    }

    [HttpPost]
    public void Post([FromBody] NationalPark nationalPark)
    {
      _db.NationalParks.Add(nationalPark);
      _db.SaveChanges();
    }

    [HttpGet("{id}")] // PAGINATION PART 2
    public ActionResult<NationalPark> Get(int id)
    {
        var nationalPark =  _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
        return Ok(new Response<NationalPark>(nationalPark));
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NationalPark nationalPark)
    {
        nationalPark.NationalParkId = id;
        _db.Entry(nationalPark).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var nationalParkToDelete = _db.NationalParks.FirstOrDefault(entry => entry.NationalParkId == id);
      _db.NationalParks.Remove(nationalParkToDelete);
      _db.SaveChanges();
    }
  }
}