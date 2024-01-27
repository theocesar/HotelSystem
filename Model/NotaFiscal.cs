using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


namespace HotelEntity {

    public class NotaFiscal {

        [Key]
        public int CodNota {get;set;}
        [StringLength(64)]
        public string? TipoPagamento {get; set;}
        public int CodReserva {get; set;}
        [StringLength(100)]
        public double ValorTotal {get;set;}
        public Reservas? Reserva {get;set;}
    }
}