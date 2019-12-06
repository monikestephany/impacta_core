using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desenvolvimento.Projeto01.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "Codigo é obrigatorio")]
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatorio")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preço é obrigatorio")]
        public double? Preco { get; set; }
    }
}
