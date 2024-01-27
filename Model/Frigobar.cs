using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace HotelEntity {

    public class Frigobar{

        [Key]
        public int CodigoItem    {get;set;}

        [StringLength(64)]
        public string? Nome {get; set;}
        
        public double Valor{get;set;}

    }
}