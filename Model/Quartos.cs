using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


namespace HotelEntity {

    public class Quartos {

        [Key]
        public int CodQuarto {get;set;}
        public int Numero {get; set;}
        public int CapacidadeMaxima {get; set;}
        public double Valor {get; set;}
        [StringLength(100)]
        public string? TipoQuarto {get; set;}
        public bool Adaptado {get;set;}

        
    }
}