using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Services;
using API.Controllers.DTO;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarDetailesController(ApplicationDbContext _context) : ControllerBase
  {
    // GET: api/CarDetailes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarDetailes>>> GetCarDetailes()
    {
      return await _context.CarDetailes.ToListAsync();
    }

    // GET: api/CarDetailes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CarDetailes>> GetCarDetailes(int id)
    {
      var carDetailes = await _context.CarDetailes.FindAsync(id);

      if (carDetailes == null)
      {
        return NotFound();
      }

      return carDetailes;
    }

    // PUT: api/CarDetailes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCarDetailes(int id, CarDetailes carDetailes)
    {
      if (id != carDetailes.Id)
      {
        return BadRequest();
      }

      _context.Entry(carDetailes).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CarDetailesExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/CarDetailes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CarDetailes>> PostCarDetailes(AddCar newCar)
    {
      CarDetailes newCarData = new CarDetailes()
      {
        CarBrand = newCar.CarBrand,
        CarDescription = newCar.CarDescription,
        CarPrice = newCar.CarPrice,
        Damage = newCar.Damage,
        CreatedDate = DateTime.Now,
        EditedDate = null
      };

      _context.CarDetailes.Add(newCarData);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCarDetailes", new { id = newCarData.Id }, newCarData);
    }

    // DELETE: api/CarDetailes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarDetailes(int id)
    {
      var carDetailes = await _context.CarDetailes.FindAsync(id);
      if (carDetailes == null)
      {
        return NotFound();
      }

      _context.CarDetailes.Remove(carDetailes);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CarDetailesExists(int id)
    {
      return _context.CarDetailes.Any(e => e.Id == id);
    }
  }
}
