using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BabyShop.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Column("ClienteId")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }
        
        public string Estado { get; set; }
        
        public string Municipio { get; set; }

        public string Endereco { get; set; }
        
        public string Telefone { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataExclusao { get; set; }

    }
}