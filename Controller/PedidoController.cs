using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {

        [HttpPost("addPedido")]
        public IActionResult AddPedido([FromBody] Pedido pedido)
        {
            using var _context = new HotelCodeFContext();
            _context.Pedido.Add(pedido);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("getPedido")]
        public List<Pedido> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Pedido.ToList();
        }
        [HttpGet("getPedidoID/{id}")]
        public IActionResult GetPedidoByID(int id)
        {
            using var _context = new HotelCodeFContext();
            var item = _context.Pedido.FirstOrDefault(t => t.CodProduto == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut("updatePedido/{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            using var _context = new HotelCodeFContext();
            var existingPedido = _context.Pedido.FirstOrDefault(r => r.CodProduto == id);

            if (existingPedido == null)
            {
                return NotFound();
            }

            _context.Entry(existingPedido).CurrentValues.SetValues(pedido);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deletePedido/{id}")]
        public IActionResult Delete(int id)
        {
            using var _context = new HotelCodeFContext();
            var pedido = _context.Pedido.FirstOrDefault(r => r.CodProduto == id);

            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            _context.SaveChanges();
            return Ok();
        }
    }
}