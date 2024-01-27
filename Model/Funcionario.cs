using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace HotelEntity {

    public class Funcionario{

        [Key]
        public int IdFuncionario {get;set;}

        [StringLength(64)]
        public string? Nome {get; set;}
        [StringLength(64)]
        public string? TipoFuncionario {get; set;}

    }
}