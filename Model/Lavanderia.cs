using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace HotelEntity {

    public class Lavanderia{

        [Key]
        public int CodigoLavanderia {get;set;}

        [StringLength(100)]
        public string? Descricao {get; set;}
        
        public double Valor{get;set;}

    }
}