using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class LavanderiaController : Controller
    {

        [HttpPost("addLavanderia")]
        public IActionResult AddLavanderia([FromBody] Lavanderia lavanderia)
        {
            using var _context = new HotelCodeFContext();
            _context.Lavanderia.Add(lavanderia);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("addServicoLavanderia")]
        public IActionResult AddSLavanderia([FromBody] ServicoLavanderia slavanderia)
        {
            using var _context = new HotelCodeFContext();
            _context.ServicoLavanderia.Add(slavanderia);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("getLavanderia")]
        public List<Lavanderia> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Lavanderia.ToList();
        }

        [HttpGet("getServicoLavanderia")]
        public List<ServicoLavanderia> GetServicoLavanderia()
        {
            using var _context = new HotelCodeFContext();
            return _context.ServicoLavanderia.ToList();
        }
        
        [HttpPut("updateLavanderia/{codigoLavanderia}")]
        public IActionResult Put(int codigoLavanderia, [FromBody] Lavanderia lavanderia)
        {
            using var _context = new HotelCodeFContext();
            var existingLavanderia = _context.Lavanderia.FirstOrDefault(r => r.CodigoLavanderia == codigoLavanderia);

            if (existingLavanderia == null)
            {
                return NotFound();
            }

            _context.Entry(existingLavanderia).CurrentValues.SetValues(lavanderia);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteLavanderia/{codigoLavanderia}")]
        public IActionResult Delete(int codigoLavanderia)
        {
            using var _context = new HotelCodeFContext();
            var lavanderia = _context.Lavanderia.FirstOrDefault(r => r.CodigoLavanderia == codigoLavanderia);

            if (lavanderia == null)
            {
                return NotFound();
            }

            _context.Lavanderia.Remove(lavanderia);
            _context.SaveChanges();
            return Ok();
        }
    }
}