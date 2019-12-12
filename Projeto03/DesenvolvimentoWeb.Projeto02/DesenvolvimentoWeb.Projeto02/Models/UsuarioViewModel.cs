using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Models
{
    public class UsuarioViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Mínimo de 6 caracteres.",
            MinimumLength = 6)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }

    }
}
