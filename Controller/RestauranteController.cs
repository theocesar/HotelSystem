using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : Controller
    {

        [HttpPost("addRestaurante")]
        public IActionResult AddRestaurante([FromBody] Restaurante restaurante)
        {
            using var _context = new HotelCodeFContext();
            _context.Restaurante.Add(restaurante);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("getRestaurante")]
        public List<Restaurante> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Restaurante.ToList();
        }
        [HttpGet("getRestauranteID/{id}")]
        public IActionResult GetRestauranteByID(int id)
        {
            using var _context = new HotelCodeFContext();
            var item = _context.Restaurante.FirstOrDefault(t => t.CodigoProduto == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("updateRestaurante/{id}")]
        public IActionResult Put(int id, [FromBody] Restaurante restaurante)
        {
            using var _context = new HotelCodeFContext();
            var existingRestaurante = _context.Restaurante.FirstOrDefault(r => r.CodigoProduto == id);

            if (existingRestaurante == null)
            {
                return NotFound();
            }

            _context.Entry(existingRestaurante).CurrentValues.SetValues(restaurante);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteRestaurante/{id}")]
        public IActionResult Delete(int id)
        {
            using var _context = new HotelCodeFContext();
            var restaurante = _context.Restaurante.FirstOrDefault(r => r.CodigoProduto == id);

            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurante.Remove(restaurante);
            _context.SaveChanges();
            return Ok();
        }
    }
}