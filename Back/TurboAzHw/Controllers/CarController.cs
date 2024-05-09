using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurboAzHw.DbContexts;
using TurboAzHw.Models;

namespace TurboAzHw.Controllers
{
    [ApiController]
    [Route("Car")]
    public class CarController : ControllerBase
    {
        private readonly CarContext _dbContext;

        public CarController(CarContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Cars")]
        public async Task<IActionResult> GetCars()
        {
            var ps = await _dbContext.Cars.ToListAsync();

            return Ok(ps);
        }

        [HttpGet("Car/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var product = await _dbContext.Cars.FirstOrDefaultAsync(p => p.Id == id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car car )
        {
            if (car == null)
            {
                return BadRequest("Car object is null");
            }

            Car p = new Car()
            {
                Name = "Mercedes",
                Description = "2.0 L/320 a.g./Plug-in Hibrid",
                Model = "E 300 e",
                Price = 77180,
                Speed = 200,
                Color = "Black",
                Image = "https://turbo.azstatic.com/uploads/full/2024%2F02%2F22%2F20%2F18%2F38%2F3938d6fc-aa4f-4e5b-90d4-502802f29601%2F32444_OikwS_ZIYofkU92pw8zouQ.jpg"
            };
            _dbContext.Cars.Add(p);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, p);
        }
    }
}
