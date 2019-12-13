using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Models
{
    public class PagamentoEvento
    {
        public int IdEvento { get; set; }
        public string Cpf { get; set; }
        public string NumeroCartao { get; set; }
        public double Valor { get; set; }
        public int Status { get; set; }
    }
}
