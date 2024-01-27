using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


namespace HotelEntity {

    public class Cliente {

        [Key]    
        public int IdCliente {get;set;}

        [StringLength(64)]
        public string? Nome {get; set;}
        [StringLength(100)]
        public string? Endereco {get; set;}
        [StringLength(50)]
        public string? Nacionalidade {get; set;}
        [StringLength(50)]
        public string? Email {get; set;}
        [StringLength(11)]
        public string? Telefone {get; set;}
        
    }
}