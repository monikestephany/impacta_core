using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Models
{
    public class Participante
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public Evento EventoInfo { get; set; }
    }
}
