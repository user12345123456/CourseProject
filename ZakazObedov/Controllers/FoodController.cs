using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakazObedov.DataAccess;
using ZakazObedov.Entities;

namespace ZakazObedov.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        public readonly ValuationDBContext _valuationContext;
        public FoodController(ValuationDBContext valuationContext)
        {
            _valuationContext = valuationContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAll()
        {
            return await _valuationContext.Pizzas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Pizza pizza)
        {
            await _valuationContext.Pizzas.AddAsync(pizza);
            await _valuationContext.SaveChangesAsync();
            return pizza.Id;

        }

        [HttpGet]
        public async Task<ActionResult<Pizza>> GetById(int id)
        {
            var pizza = await _valuationContext.Pizzas.FindAsync(id);
            return Ok(pizza);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArt(int id, [FromBody] Pizza pizza)
        {
            var existingPizza = await _valuationContext.Pizzas.FindAsync(id);
            existingPizza.Id = pizza.Id;
            existingPizza.Name = pizza.Name;
            existingPizza.Price = pizza.Price;
            existingPizza.Discription = pizza.Discription;
            _valuationContext.Pizzas.Update(existingPizza);
            await _valuationContext.SaveChangesAsync();

            return NoContent();
        }

    }
}