using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required(ErrorMessage = "Nome é obrigatorio!")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email é obrigatorio!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Display(Name = "Cpf:")]
        [Required(ErrorMessage = "CPF é obrigatorio!")]
        [StringLength(11, MinimumLength = 11,ErrorMessage ="Cpf Inválido!")]
        public string Cpf { get; set; }

        [Display(Name = "Dt. Nascimento:")]
        [Required(ErrorMessage = "Data de nascimento é obrigatorio!")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento Inválido!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataNascimento { get; set; }

        public Evento EventoInfo { get; set; }
    }
}
