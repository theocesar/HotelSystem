using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


namespace HotelEntity {

    public class Filial {

        [Key]
        public int CodFilial {get;set;}
        [StringLength(64)]
        public string? Nome {get; set;}
        public int CodQuarto {get; set;}
        [StringLength(100)]
        public string? Endereco {get; set;}
        public bool Adaptado {get;set;}
        public int QuantidadeEstrelas {get; set;}
        public Quartos? Quarto {get;set;}
    }
}