using DesenvolvimentoWeb.WebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.WebApi.Model
{
    public static class DbInicializer
    {
        public static void Initialize(PagamentoContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
