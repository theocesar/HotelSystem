using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


namespace HotelEntity {

    public class Reservas {

        [Key]
        public int CodReserva {get;set;}
        public DateOnly DTEntrada {get;set;}
        public DateOnly DTSaida {get;set;}
        public bool CapacidadeOpcional {get;set;}
        public DateOnly DTCancelamento {get;set;}
        public int IdFuncionario {get;set;}
        public int IdCliente {get;set;}
        public int Numero {get;set;}
        public int CodQuarto {get;set;}
        public Funcionario? Funcionario {get;set;}
        public Cliente? Cliente {get;set;}
        public Quartos? Quarto {get;set;}
    }
}