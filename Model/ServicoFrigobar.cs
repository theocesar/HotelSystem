using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace HotelEntity {

    [PrimaryKey(nameof(CodItem), nameof(CodReserva), nameof(DataSolicitacao))]
    public class ServicoFrigobar {

        public int CodItem {get;set;}
        public int CodReserva {get; set;}
        public DateOnly DataSolicitacao {get;set;}
        public Reservas? Reserva {get;set;}
        public Frigobar? Frigobar {get;set;}
    }
}