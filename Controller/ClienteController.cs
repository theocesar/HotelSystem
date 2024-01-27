using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {

        [HttpPost("addCliente")]
        public IActionResult AddQuartos([FromBody] Cliente cliente)
        {
            using var _context = new HotelCodeFContext();
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("getCliente")]
        public List<Cliente> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Cliente.ToList();
        }
        [HttpGet("getClienteID/{id}")]
        public IActionResult GetClienteByID(int id)
        {
            using var _context = new HotelCodeFContext();
            var item = _context.Cliente.FirstOrDefault(t => t.IdCliente == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("updateCliente/{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            using var _context = new HotelCodeFContext();
            var existingCliente = _context.Cliente.FirstOrDefault(r => r.IdCliente == id);

            if (existingCliente == null)
            {
                return NotFound();
            }

            _context.Entry(existingCliente).CurrentValues.SetValues(cliente);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteCliente/{id}")]
        public IActionResult Delete(int id)
        {
            using var _context = new HotelCodeFContext();
            var cliente = _context.Cliente.FirstOrDefault(r => r.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
            return Ok();
        }
    }
}