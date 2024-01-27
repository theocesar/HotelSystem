using Microsoft.AspNetCore.Mvc;


namespace HotelEntity
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        [HttpPost("addReservas")]
        public void Post([FromBody] Reservas reserva)
        {
            using var _context = new HotelCodeFContext();
            _context.Reserva.Add(reserva);
            _context.SaveChanges();
        }

        private static decimal CalcularDiaria(int idQuarto, bool capacidadeOpcional)
        {
            using var _context = new HotelCodeFContext();
            decimal valorQuarto = _context.Quartos
                .Where(q => q.CodQuarto == idQuarto)
                .Select(q => (decimal)q.Valor) 
                .FirstOrDefault();

            if (valorQuarto == 0)
            {
                throw new Exception("Quarto não encontrado.");
            }

            decimal aumentoDiaria = capacidadeOpcional ? valorQuarto * 0.25m : 0;

            return valorQuarto + aumentoDiaria;
        }

        
        [HttpPost("GenerateNotaFiscal/{idReserva}")]
        public IActionResult GerarNota(int idReserva)
        {
            try
            {
                using var _context = new HotelCodeFContext();

                var reserva = _context.Reserva.FirstOrDefault(r => r.CodReserva == idReserva);
                if (reserva == null)
                {
                    return NotFound("Reserva não encontrada.");
                }

                decimal diaria = CalcularDiaria(reserva.CodQuarto, reserva.CapacidadeOpcional);

                var valorServicosRestaurante = _context.Restaurante
                    .Join(_context.Pedido, r => r.CodigoProduto, p => p.CodProduto, (r, p) => new { Restaurante = r, Pedido = p })
                    .Where(rp => rp.Pedido.CodReserva == idReserva)
                    .Sum(rp => rp.Pedido.Quantidade * rp.Restaurante.Valor);

                var valorServicosLavanderia = _context.Lavanderia
                    .Join(_context.ServicoLavanderia, l => l.CodigoLavanderia, sl => sl.CodLavanderia, (l, sl) => new { Lavanderia = l, ServicoLavanderia = sl })
                    .Where(sll => sll.ServicoLavanderia.CodReserva == idReserva)
                    .Sum(sll => sll.Lavanderia.Valor);

                var valorServicosFrigobar = _context.Frigobar
                    .Join(_context.ServicoFrigobar, f => f.CodigoItem, sf => sf.CodItem, (f, sf) => new { Frigobar = f, ServicoFrigobar = sf })
                    .Where(sff => sff.ServicoFrigobar.CodReserva == idReserva)
                    .Sum(sff => sff.Frigobar.Valor);

                var valorServicos = valorServicosRestaurante + valorServicosLavanderia + valorServicosFrigobar;


                decimal valorTotalNota = diaria + Convert.ToDecimal(valorServicos);

                var nota = new
                {
                    IdReserva = idReserva,
                    ValorDiaria = diaria,
                    ValorServicos = valorServicos,
                    Total = "R$" + valorTotalNota
                };

                return Ok(nota);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao gerar a nota: {ex.Message}");
            }
        }

        [HttpGet("getReservas")]
        public List<Reservas> Get()
        {
            using var _context = new HotelCodeFContext();
            return _context.Reserva.ToList();
        }
        [HttpGet("getReservaID/{id}")]
        public IActionResult Get(int id)
        {
            using var _context = new HotelCodeFContext();
            var item = _context.Reserva.FirstOrDefault(t => t.CodReserva == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("getQuartosDisponiveis")]
        public IActionResult GetQuartosDisponiveis()
        {
            using var _context = new HotelCodeFContext();

            DateTime dataAtual = DateTime.Now;

            var reservas = _context.Reserva.ToList();

            var quartosDisponiveis = from quarto in _context.Quartos.ToList()
                                    where !reservas.Any(reserva => reserva.CodQuarto == quarto.CodQuarto && reserva.DTSaida.ToDateTime(TimeOnly.MinValue) >= dataAtual)
                                    select quarto;

            return Ok(quartosDisponiveis.ToList());
        }

        [HttpGet("reservasPorFuncionario/{nomeFuncionario}")]
        public IActionResult GetReservasPorFuncionario(string nomeFuncionario)
        {
            using var _context = new HotelCodeFContext();

            var reservasPorFuncionario = from reserva in _context.Reserva
                                         join cliente in _context.Cliente on reserva.IdCliente equals cliente.IdCliente
                                         join quarto in _context.Quartos on reserva.CodQuarto equals quarto.CodQuarto
                                         join funcionario in _context.Funcionario on reserva.IdFuncionario equals funcionario.IdFuncionario
                                         where funcionario.Nome == nomeFuncionario
                                         select new
                                         {
                                             CodigoReserva = reserva.CodReserva,
                                             DtEntrada = reserva.DTEntrada,
                                             DtSaida = reserva.DTSaida,
                                             NomeCliente = cliente.Nome,
                                             NumeroQuarto = quarto.Numero
                                         };

            return Ok(reservasPorFuncionario.ToList());
        }

        [HttpGet("historicoConsumo/{idReserva}")]
        public IActionResult GetHistoricoConsumo(int idReserva)
        {
            try
            {
                using var _context = new HotelCodeFContext();

                List<object> historicoConsumo = [];

                var historicoConsumoRestaurante = from pedido in _context.Pedido
                                                    join reserva in _context.Reserva on pedido.CodReserva equals reserva.CodReserva
                                                    join restaurante in _context.Restaurante on pedido.CodProduto equals restaurante.CodigoProduto
                                                    where pedido.CodReserva == idReserva
                                                    select new
                                                    {
                                                        CodigoReserva = reserva.CodReserva,
                                                        NomeProduto = restaurante.Nome,
                                                        pedido.Quantidade,
                                                        pedido.EntregueQuarto,
                                                        ValorProduto = restaurante.Valor
                                                    };

                historicoConsumo.AddRange(historicoConsumoRestaurante);

                var historicoConsumoFrigobar = from SFrigobar in _context.ServicoFrigobar
                                                join reserva in _context.Reserva on SFrigobar.CodReserva equals reserva.CodReserva
                                                join frigobar in _context.Frigobar on SFrigobar.CodItem equals frigobar.CodigoItem
                                                where SFrigobar.CodReserva == idReserva
                                                select new
                                                {
                                                    NomeProduto = frigobar.Nome,
                                                    ValorProduto = frigobar.Valor,
                                                    DataConsumo = SFrigobar.DataSolicitacao
                                                };

                historicoConsumo.AddRange(historicoConsumoFrigobar);

                var historicoConsumoLavanderia = from SLavanderia in _context.ServicoLavanderia
                                                    join reserva in _context.Reserva on SLavanderia.CodReserva equals reserva.CodReserva
                                                    join lavanderia in _context.Lavanderia on SLavanderia.CodLavanderia equals lavanderia.CodigoLavanderia
                                                    where SLavanderia.CodReserva == idReserva
                                                    select new
                                                    {
                                                        DescricaoServico = lavanderia.Descricao,
                                                        ValorProduto = lavanderia.Valor,
                                                        DataServico = SLavanderia.DataPrestacao
                                                    };

                historicoConsumo.AddRange(historicoConsumoLavanderia);

                return Ok(historicoConsumo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter histórico de consumo: {ex.Message}");
            }
        }

        [HttpPut("updateReserva/{id}")]
        public IActionResult Put(int id, [FromBody] Reservas reserva)
        {
            using var _context = new HotelCodeFContext();
            var existingReserva = _context.Reserva.FirstOrDefault(r => r.CodReserva == id);

            if (existingReserva == null)
            {
                return NotFound();
            }

            _context.Entry(existingReserva).CurrentValues.SetValues(reserva);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("deleteReserva/{id}")]
        public IActionResult Delete(int id)
        {
            using var _context = new HotelCodeFContext();
            var reserva = _context.Reserva.FirstOrDefault(r => r.CodReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            _context.SaveChanges();
            return Ok();
        }
    }
}