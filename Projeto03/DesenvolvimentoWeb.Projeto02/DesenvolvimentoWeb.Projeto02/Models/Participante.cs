using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [Display(Name = "Evento:")]
        [Required]
        public int IdEvento { get; set; }

        [Display(Name = "Nome:")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Cpf:")]
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }

        [Display(Name = "Dt. Nascimento:")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public Evento EventoInfo { get; set; }
    }
}
