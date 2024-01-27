using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrigobarController : Controller
    {

        [HttpPost("addFrigobar")]
        public IActionResult AddFrigobar([FromBody] Frigobar frigobar)
        {
            using var _context = new HotelCodeFContext();
            _context.Frigobar.Add(frigobar);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("addServicoFrigobar")]
        public IActionResult AddSFrigobar([FromBody] ServicoFrigobar sfrigobar)
        {
            using var _context = new HotelCodeFContext();
            _context.ServicoFrigobar.Add(sfrigobar);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("getFrigobar")]
        public List<Frigobar> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Frigobar.ToList();
        }

        [HttpGet("getServicoFrigobar")]
        public List<ServicoFrigobar> GetServicoFrigobar()
        {
            using var _context = new HotelCodeFContext();
            return _context.ServicoFrigobar.ToList();
        }

        
        [HttpPut("updateFrigobar/{codigoItem}")]
        public IActionResult Put(int codigoItem, [FromBody] Frigobar frigobar)
        {
            using var _context = new HotelCodeFContext();
            var existingFrigobar = _context.Frigobar.FirstOrDefault(r => r.CodigoItem == codigoItem);

            if (existingFrigobar == null)
            {
                return NotFound();
            }

            _context.Entry(existingFrigobar).CurrentValues.SetValues(frigobar);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteFrigobar/{codigoItem}")]
        public IActionResult Delete(int codigoItem)
        {
            using var _context = new HotelCodeFContext();
            var frigobar = _context.Frigobar.FirstOrDefault(r => r.CodigoItem == codigoItem);

            if (frigobar == null)
            {
                return NotFound();
            }

            _context.Frigobar.Remove(frigobar);
            _context.SaveChanges();
            return Ok();
        }
    }
}