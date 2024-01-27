using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace HotelEntity {

    [PrimaryKey(nameof(CodProduto), nameof(CodReserva), nameof(DataPedido))]
    public class Pedido {

        public int CodProduto {get;set;}
        public int CodReserva {get; set;}
        public int Quantidade {get;set;}
        public DateOnly DataPedido {get;set;}
        public bool EntregueQuarto {get;set;}
        public Restaurante? Restaurante {get;set;}
        public Reservas? Reserva {get;set;}
    }
}