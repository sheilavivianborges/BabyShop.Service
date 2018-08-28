using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabyShop.Service.Models
{
    /// <summary>
    /// Classe que representa os dados de acesso de um cliente
    /// </summary>
    public class Acesso
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}