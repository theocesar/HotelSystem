using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialController : Controller
    {

        [HttpPost("addFilial")]
        public IActionResult AddFilial([FromBody] Filial filial)
        {
            using var _context = new HotelCodeFContext();
            _context.Filial.Add(filial);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("getFilial")]
        public List<Filial> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Filial.ToList();
        }

        [HttpGet("getFilialCodigo/{codFilial}")]
        public IActionResult GetPedidoByID(int codFilial)
        {
            using var _context = new HotelCodeFContext();
            var item = _context.Filial.FirstOrDefault(t => t.CodFilial == codFilial);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("updateFilial/{codFilial}")]
        public IActionResult Put(int codFilial, [FromBody] Filial filial)
        {
            using var _context = new HotelCodeFContext();
            var existingFilial = _context.Filial.FirstOrDefault(r => r.CodFilial == codFilial);

            if (existingFilial == null)
            {
                return NotFound();
            }

            _context.Entry(existingFilial).CurrentValues.SetValues(filial);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteFilial/{codFilial}")]
        public IActionResult Delete(int codFilial)
        {
            using var _context = new HotelCodeFContext();
            var filial = _context.Filial.FirstOrDefault(r => r.CodFilial == codFilial);

            if (filial == null)
            {
                return NotFound();
            }

            _context.Filial.Remove(filial);
            _context.SaveChanges();
            return Ok();
        }
    }
}