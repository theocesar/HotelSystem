using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : Controller
    {

        [HttpPost("addQuartos")]
        public IActionResult AddQuartos([FromBody] Quartos quarto)
        {
            using var _context = new HotelCodeFContext();
            _context.Quartos.Add(quarto);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("getQuartos")]
        public List<Quartos> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Quartos.ToList();
        }
        [HttpGet("getQuartoID/{id}")]
        public IActionResult GetQuartoByID(int id)
        {
            using var _context = new HotelCodeFContext();
            var item = _context.Quartos.FirstOrDefault(t => t.CodQuarto == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("updateQuarto/{id}")]
        public IActionResult Put(int id, [FromBody] Quartos quarto)
        {
            using var _context = new HotelCodeFContext();
            var existingQuarto = _context.Quartos.FirstOrDefault(r => r.CodQuarto == id);

            if (existingQuarto == null)
            {
                return NotFound();
            }

            _context.Entry(existingQuarto).CurrentValues.SetValues(quarto);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteQuarto/{id}")]
        public IActionResult Delete(int id)
        {
            using var _context = new HotelCodeFContext();
            var quarto = _context.Quartos.FirstOrDefault(r => r.CodQuarto == id);

            if (quarto == null)
            {
                return NotFound();
            }

            _context.Quartos.Remove(quarto);
            _context.SaveChanges();
            return Ok();
        }
    }
}