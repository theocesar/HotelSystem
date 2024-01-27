using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace HotelEntity {

    [PrimaryKey(nameof(CodLavanderia), nameof(CodReserva), nameof(DataPrestacao))]
    public class ServicoLavanderia {

        public int CodLavanderia {get;set;}
        public int CodReserva {get; set;}
        public DateOnly DataPrestacao {get;set;}
        public Reservas? Reserva {get;set;}
        public Lavanderia? Lavanderia {get;set;}
    }
}