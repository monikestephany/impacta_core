using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.WebApi.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string Cpf { get; set; }
        public string NumeroCartao { get; set; }
        public double Valor { get; set; }
        public int Status { get; set; }
    }
}
